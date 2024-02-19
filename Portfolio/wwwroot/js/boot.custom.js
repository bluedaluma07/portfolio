"use strict";

Blazor.start({
    // 再試行のペースは2秒に1回とし、再試行回数は
    // これを1年間継続するのに相当する回数を指定してみました。
    reconnectionOptions: { maxRetries: 15768000, retryIntervalMilliseconds: 2000 },
});

const observer = new MutationObserver(mutations => {
    // 監視対象の HTML に "変化" があると、ここが実行される
    mutations.forEach(mutation => {
        // 変化があった、監視対象 HTML 要素の CSS クラスを調べ...
        const classList = mutation.target.classList;
        // components-reconnect-rejected` という CSS クラス名が見つかったなら、
        if (classList.contains('components-reconnect-rejected') === true) {
            // ブラウザのページ再読込を実行
            window.location.reload();
        }
    });
});

// 「再接続中」モーダル表示の HTML 要素を取得
const reconnectModal = document.getElementById('components-reconnect-modal');

if (reconnectModal !== null) {
    // その HTML 要素を、先ほど初期化した MutationObserver インスタンスで監視開始
    observer.observe(reconnectModal, { attributes: true, subtree: false });
}

