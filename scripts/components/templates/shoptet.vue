<template>
    <div class="shoptet-external-iframe-content">
        <h1 class="std-header">Lorem ipsum dolor sit amet</h1>

        <ul class="list-reset">
            <li>
                <!-- EXAMPLE: simple system message. type: Sucess notice -->

                <div class="system-message-success system-message-wrap">
                    <div class="system-message-outer">
                        <div class="system-message-inner">
                            <div class="system-message-content">This is an example Success notice. <span class="show-tooltip tooltip-icon" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aliquam erat volutpat."></span></div>
                            <div class="system-message-buttons"><a class="system-message-close system-message-close-trigger" href="#" title="Zavřít"></a></div>
                        </div>
                    </div>
                </div>
            </li>

            <li>
                <!-- EXAMPLE: simple system message. type: Tip notice -->

                <div class="system-message-alert system-message-wrap">
                    <div class="system-message-outer">
                        <div class="system-message-inner">
                            <div class="system-message-content">This is an example Tip notice.</div>

                        </div>
                    </div>
                </div>
            </li>

            <li>
                <!-- EXAMPLE: simple system message. type: Warning notice -->

                <div class="system-message-error system-message-wrap">
                    <div class="system-message-outer">
                        <div class="system-message-inner">
                            <div class="system-message-content">This is an example Warning notice with <code>code highlight</code>.</div>
                            <div class="system-message-buttons"><a href="/" title="Více" class="btn btn-default btn-md no-disable">Více</a><a class="system-message-close system-message-close-trigger" href="#" title="Zavřít"></a></div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>

        <div class="std-perex std-perex-condensed">
            <div>
                Lorem ipsum dolor sit amet.
            </div>
        </div>

        <h2 class="std-header">První H2 na stránce</h2>

        <div class="std-perex std-perex-condensed">
            <div>
                Toto je <strong>Perex</strong> se zúženými okraji nahoře a dole. Používá se pro jednověté nápovědy. Zabírá méně místa.
            </div>
        </div>

        <h2 class="std-header"><span>Další H2 na stránce</span></h2>

        <p>
            Toto je odstavec s <a href="#" title="Hyperlink">odkazem</a> a <strong>zvýrazněným textem</strong> a s <em>vyznačenou &gt; cestou</em>.
        </p>

        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris cursus ligula vehicula quam scelerisque blandit.
            Cras faucibus pellentesque ex et faucibus. Praesent eu orci <em>Toto je Path highlight &gt; blandit &gt; eu et odio</em>.
            Curabitur sed neque nunc. Fusce vitae pulvinar dui. Vivamus gravida sapien a magna auctor faucibus.
            Vivamus urna eros, semper id tellus eu, efficitur porta justo. <a href="#" title="link" target="_blank">This is Hyperlink example</a> quam ut leo pulvinar suscipit.
            Sed eu nisl diam. Suspendisse potenti. Pellentesque habitant morbi tristique senectus et netus et malesuada
            fames ac turpis egestas.
        </p>

        <ul>
            <li>
                <strong>Perex</strong> - vysvětlení složitější stránky,
                kde jsme a k čemu to slouží
            </li>
            <li>
                <strong>Tip notice</strong> - nedávat zavíratelný,
                používat odděleně i když je na stránce přítomný perex, primárně se vkládá pod taby, pokud se vztahuje k celé stránce, tak nad taby
            </li>
            <li>
                <strong>Success a warning notices</strong> - dávají se mezi
                nadpis a taby, nejsou zavíratelný
            </li>
        </ul>

        <h2 class="std-header"><span>Záložky</span></h2>

        <div id="tabs-default" class="ui-tabs std-tabs">
            <ul>
                <li>
                    <a href="#a1">příklad záložky</a>
                </li>
                <li>
                    <a href="#a2">příklad záložky</a>
                </li>
            </ul>
            <div id="a1"></div>
            <div id="a2"></div>
        </div>

        <div id="tabs-unfilled" class="tabs ui-tabs">
            <ul>
                <li>
                    <a href="#c1">příklad záložky</a>
                </li>
                <li>
                    <a href="#c2">příklad záložky</a>
                </li>
                <li>
                    <a href="#c3">příklad záložky</a>
                </li>
                <li>
                    <a href="#c4">příklad záložky</a>
                </li>
                <li>
                    <a href="#c5">příklad záložky</a>
                </li>
            </ul>
            <div id="c1">#c1</div>
            <div id="c2">#c2</div>
            <div id="c3">#c3</div>
            <div id="c4">#c4</div>
            <div id="c5">#c5</div>
        </div>

    </div>
</template>

<script>


export default {
    data() {
        return {
            linkData:""
        }
    },
    methods: {
    },
    created() {
        var that = this;
    }
}
</script>

<style scoped>

</style>