using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Reflection;

namespace Portfolio.Components.Validation.Base
{
    /// <summary>
    /// フィールドバリデーションの基底クラス
    /// </summary>
    /// <typeparam name="TItem">入力項目の型</typeparam>
    public abstract class FieldValidatorBase<TItem> : ComponentBase, IDisposable
    {
        /// <summary>
        /// プロパティ情報のキャッシュ
        /// </summary>
        private PropertyInfo? _propertyInfoCache;

        /// <summary>
        /// 現在の編集コンテキスト。このコンテキストはフォームの状態を表します。
        /// </summary>
        [CascadingParameter]
        protected EditContext? CurrentEditContext { get; private set; }
        private EditContext? _previousEditContext;

        /// <summary>
        /// バリデーション対象のプロパティ
        /// </summary>
        [Parameter]
        [EditorRequired]
        public Expression<Func<TItem>>? For { get; set; }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        [Parameter]
        [EditorRequired]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// オブジェクトの特定のプロパティの ID を提供
        /// </summary>
        private FieldIdentifier Field { get; set; }

        /// <summary>
        /// バリデーションエラーメッセージの格納場所
        /// </summary>
        private ValidationMessageStore? _messageStore;
        private bool _disposedValue;

        /// <summary>
        /// パラメータが設定された後、このメソッドが呼び出される。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        protected override void OnParametersSet()
        {
            // 必須パラメーターチェック
            if (CurrentEditContext is null)
                throw new InvalidOperationException($"{nameof(FieldValidatorBase<TItem>)} には {nameof(EditContext)} タイプのパラメータが必須です。");
            if (For is null)
                throw new InvalidOperationException($"{nameof(For)} は必須です。");

            if (CurrentEditContext != _previousEditContext)
            {
                // バリデーションに必要なオブジェクトの初期化
                DetachEditContext();
                CurrentEditContext.OnValidationRequested += EditContext_OnValidationRequested;
                CurrentEditContext.OnFieldChanged += EditContext_OnFieldChanged;
                //CurrentEditContext.SetFieldCssClassProvider(new InvalidFieldCssClassProvider());
                _messageStore = new(CurrentEditContext);

                _previousEditContext = CurrentEditContext;
            }

            // FieldIdentifier の初期化
            Field = FieldIdentifier.Create(For);
        }

        /// <summary>
        /// 現在の編集コンテキストからデタッチする
        /// </summary>
        private void DetachEditContext()
        {
            // イベントハンドラー等の切り離し
            if (_previousEditContext is not null)
            {
                _previousEditContext.OnValidationRequested -= EditContext_OnValidationRequested;
                _previousEditContext.OnFieldChanged -= EditContext_OnFieldChanged;

                _messageStore = null;
            }
        }

        /// <summary>
        /// バリデーション要求時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContext_OnValidationRequested(object? sender, ValidationRequestedEventArgs e)
        {
            // Validation を要求されたら無条件にバリデーションを実行
            Validate();
        }

        /// <summary>
        /// フィールド変更時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            // もしフィールドが変更する度にバリデーションを行う使用にする場合は、
            // 以下のコメント文を解除すれば行うようになります。

            // 自分の監視対象のフィールドならバリデーションを実行
            //if (e.FieldIdentifier.Model == Field.Model && e.FieldIdentifier.FieldName == Field.FieldName)
            //{
            //    Validate();
            //}
        }

        /// <summary>
        /// バリデーションロジック
        /// </summary>
        private void Validate()
        {
            // プロパティの値を取得してバリデーションを実行
            if (_propertyInfoCache is null || _propertyInfoCache.Name != Field.FieldName)
            {
                _propertyInfoCache = Field.Model.GetType().GetProperty(Field.FieldName);
            }

            var value = (TItem)_propertyInfoCache!.GetValue(Field.Model)!;

            // 各フィールドのメッセージをクリア
            _messageStore!.Clear(Field);

            // 検証失敗の場合
            if (ValidateValue(value) is false)
            {
                // エラーメッセージ追加
                _messageStore.Add(Field, ErrorMessage!);
            }

            CurrentEditContext!.NotifyValidationStateChanged();
        }

        /// <summary>
        /// 実際のバリデーションロジックを定義するための抽象メソッド
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true:検証OK false:検証NG</returns>
        protected abstract bool ValidateValue(TItem value);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DetachEditContext();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
