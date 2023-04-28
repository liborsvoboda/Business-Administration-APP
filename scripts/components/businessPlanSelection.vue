<template>
    <div id="pricing-table" name="pricing-table" class="pricing-table">
        <div class="container">
            <div class="block-heading">
                <h1>
                    <span class="h1_bold">
                        Vyberte si váš tarif
                    </span>
                </h1>
                <div class="under_title">
                    Zvyšte počet objednávek v průměru o 7-18 % pomocí app
                </div>
                <br /><br />
                <div style="display:inline">
                    <div class="middle">
                        <div id="month" class="businessSelectionMonthOn shadow" onclick="changeSelection('month');">
                            <span style="display: inline-block;padding-top: 15px;">
                                MĚSÍČNÍ platba
                            </span>
                        </div>
                        <span style="width:3px;margin-left: -3px;margin-right: -3px;z-index: 1000;background-color: lightgray;margin-top: 0px;margin-bottom: 14px;"></span>
                        <div id="year" class="businessSelectionYearOff shadow" onclick="changeSelection('year');">
                            <span style="display: inline-block;padding-top: 15px;">
                                ROČNÍ platba
                            </span>
                        </div>
                        <img src="/images/product/2month_gratis.png" style="filter: grayscale(100%);padding-left:15px;" />
                    </div>
                </div>
                <br />
                <br />
                <div class="row justify-content-md-center">


                    <div class="col-md-5 col-lg-3" style="padding-left: 7px;padding-right: 7px;min-width: 280px;">
                        <div class="item">
                            <div class="heading" style="margin-bottom: 1rem;">
                                <h3 class="businessHeader mycolor"><strong>START</strong></h3>

                                <div class="features">
                                    <h4><span class="feature">do <strong>{{appSettings[1].creditVariant.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}}</strong></span> unikátních <br />návštěv za měsíc</h4>
                                </div>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně domén
                                <span class="businesstooltiptext font-weight-normal">Zobrazte notifikace na všech vašich stránkách a doménách.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně notifikací
                                <span class="businesstooltiptext font-weight-normal">Zobrazte tolik notifikací, kolik vaše weby snesou.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Přizpůsobení notifikací
                                <span class="businesstooltiptext font-weight-normal">Nastavte si vlastní pravidla zobrazování a časování notifikací. Např. Zpoždění první notifikace.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Aktuální návštěvníci
                                <span class="businesstooltiptext font-weight-normal">
                                    Ukažte, jak to u vás žije a zobrazte množství lidí, kteří si prohlíží vaše stránky v reálném čase.
                                    Např. 137 návštěvníků si právě prohlíží tuto stránku.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední objednávky
                                <span class="businesstooltiptext font-weight-normal">Zobrazte reálné objednávky uskutečněné ve vašem e-shopu a motivujte ostatní k nákupu.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední registrace
                                <span class="businesstooltiptext font-weight-normal">Zobrazte kontakty registrované z různých formulářů na webu. Např. webinář, stažení e-booku, zasílání newsletteru atd.</span>
                            </div>

                            <div class="businesstooltip businessItemGreen">
                                Souhrnné statistiky
                                <span class="businesstooltiptext font-weight-normal">
                                    Zobrazte celkové počty objednávek, registrací, návštěv nebo zobrazených stránek za vybrané časové období. Např. 268 návštěvníků si u nás nakoupilo za posledních 24 hodin.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Recenze a hodnocení
                                <span class="businesstooltiptext font-weight-normal">Zobrazte nejlepší recenze z portálu Heuréka CZ/SK anebo Zboží.cz.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                TOP nabídky
                                <span class="businesstooltiptext font-weight-normal">Vytvořte si notifikaci s vlastním textem a odkazem. Propagujte novinky, slevy, články, soutěže atd.</span>
                            </div>
                            <div class="businesstooltip businessItemRed">
                                Prioritní podpora
                                <span class="businesstooltiptext font-weight-normal">Nečekejte a předběhněte frontu požadavků ostatních klientů.</span>
                            </div>
                            <hr />
                            <p></p>
                            <div id="StartYear" class="price" style="display:none;">
                                <div class="pricelabel_bold_red">{{appSettings[1].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</div>
                                <span class="pricelabel_bold">{{Math.ceil(( appSettings[1].price / 12 ) * 10).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <div>Při roční platbě {{appSettings[7].price.toString().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč</div>
                                <div>(2 měsíce zdarma)</div>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/start-rok?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-start-rok'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div id="StartMonth" class="price">
                                <span class="pricelabel_bold">{{appSettings[1].price.toString().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/start-mesic?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-start-mesic'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div class="small_title"><br>Ceny jsou uvedeny bez DPH</div>
                        </div>
                    </div>

                    <div class="col-md-5 col-lg-3" style="padding-left: 7px;padding-right: 7px;min-width: 280px;">
                        <div class="item">
                            <div class="heading" style="margin-bottom: 1rem;">
                                <h3 class="businessHeader mycolor"><strong>BASIC</strong></h3>

                                <div class="features">
                                    <h4><span class="feature">do <strong>{{appSettings[2].creditVariant.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}}</strong></span> unikátních <br />návštěv za měsíc</h4>
                                </div>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně domén
                                <span class="businesstooltiptext font-weight-normal">Zobrazte notifikace na všech vašich stránkách a doménách.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně notifikací
                                <span class="businesstooltiptext font-weight-normal">Zobrazte tolik notifikací, kolik vaše weby snesou.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Přizpůsobení notifikací
                                <span class="businesstooltiptext font-weight-normal">Nastavte si vlastní pravidla zobrazování a časování notifikací. Např. Zpoždění první notifikace.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Aktuální návštěvníci
                                <span class="businesstooltiptext font-weight-normal">
                                    Ukažte, jak to u vás žije a zobrazte množství lidí, kteří si prohlíží vaše stránky v reálném čase.
                                    Např. 137 návštěvníků si právě prohlíží tuto stránku.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední objednávky
                                <span class="businesstooltiptext font-weight-normal">Zobrazte reálné objednávky uskutečněné ve vašem e-shopu a motivujte ostatní k nákupu.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední registrace
                                <span class="businesstooltiptext font-weight-normal">Zobrazte kontakty registrované z různých formulářů na webu. Např. webinář, stažení e-booku, zasílání newsletteru atd.</span>
                            </div>

                            <div class="businesstooltip businessItemGreen">
                                Souhrnné statistiky
                                <span class="businesstooltiptext font-weight-normal">
                                    Zobrazte celkové počty objednávek, registrací, návštěv nebo zobrazených stránek za vybrané časové období. Např. 268 návštěvníků si u nás nakoupilo za posledních 24 hodin.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Recenze a hodnocení
                                <span class="businesstooltiptext font-weight-normal">Zobrazte nejlepší recenze z portálu Heuréka CZ/SK anebo Zboží.cz.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                TOP nabídky
                                <span class="businesstooltiptext font-weight-normal">Vytvořte si notifikaci s vlastním textem a odkazem. Propagujte novinky, slevy, články, soutěže atd.</span>
                            </div>
                            <div class="businesstooltip businessItemRed">
                                Prioritní podpora
                                <span class="businesstooltiptext font-weight-normal">Když budete potřebovat pomoci nebo poradit, vyřešíme váš požadavek přednostně.</span>
                            </div>
                            <hr />
                            <p></p>
                            <div id="BasicYear" class="price" style="display:none;">
                                <div class="pricelabel_bold_red">{{appSettings[2].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</div>
                                <span class="pricelabel_bold">{{Math.ceil(( appSettings[2].price / 12 ) * 10).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <div>Při roční platbě {{appSettings[8].price.toString().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč</div>
                                <div>(2 měsíce zdarma)</div>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/basic-rok?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-basic-rok'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div id="BasicMonth" class="price">
                                <span class="pricelabel_bold">{{appSettings[2].price.toString().toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/basic-mesic?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-basic-mesic'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div class="small_title"><br>Ceny jsou uvedeny bez DPH</div>
                        </div>
                    </div>

                    <div class="col-md-5 col-lg-3" style="padding-left: 7px;padding-right: 7px;min-width: 280px;">
                        <div class="item item_center">
                            <div class="ribbon">NEJOBLÍBENĚJŠÍ</div>
                            <div class="heading" style="margin-bottom: 1rem;">
                                <h3 class="businessHeader mycolor"><strong>BUSINESS</strong></h3>

                                <div class="features">
                                    <h4><span class="feature">do <strong>{{appSettings[3].creditVariant.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}}</strong></span> unikátních <br />návštěv za měsíc</h4>
                                </div>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně domén
                                <span class="businesstooltiptext font-weight-normal">Zobrazte notifikace na všech vašich stránkách a doménách.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně notifikací
                                <span class="businesstooltiptext font-weight-normal">Zobrazte tolik notifikací, kolik vaše weby snesou.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Přizpůsobení notifikací
                                <span class="businesstooltiptext font-weight-normal">Nastavte si vlastní pravidla zobrazování a časování notifikací. Např. Zpoždění první notifikace.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Aktuální návštěvníci
                                <span class="businesstooltiptext font-weight-normal">
                                    Ukažte, jak to u vás žije a zobrazte množství lidí, kteří si prohlíží vaše stránky v reálném čase.
                                    Např. 137 návštěvníků si právě prohlíží tuto stránku.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední objednávky
                                <span class="businesstooltiptext font-weight-normal">Zobrazte reálné objednávky uskutečněné ve vašem e-shopu a motivujte ostatní k nákupu.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední registrace
                                <span class="businesstooltiptext font-weight-normal">Zobrazte kontakty registrované z různých formulářů na webu. Např. webinář, stažení e-booku, zasílání newsletteru atd.</span>
                            </div>

                            <div class="businesstooltip businessItemGreen">
                                Souhrnné statistiky
                                <span class="businesstooltiptext font-weight-normal">
                                    Zobrazte celkové počty objednávek, registrací, návštěv nebo zobrazených stránek za vybrané časové období. Např. 268 návštěvníků si u nás nakoupilo za posledních 24 hodin.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Recenze a hodnocení
                                <span class="businesstooltiptext font-weight-normal">Zobrazte nejlepší recenze z portálu Heuréka CZ/SK anebo Zboží.cz.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                TOP nabídky
                                <span class="businesstooltiptext font-weight-normal">Vytvořte si notifikaci s vlastním textem a odkazem. Propagujte novinky, slevy, články, soutěže atd.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Prioritní podpora
                                <span class="businesstooltiptext font-weight-normal">Když budete potřebovat pomoci nebo poradit, vyřešíme váš požadavek přednostně.</span>
                            </div>
                            <hr />
                            <p></p>
                            <div id="BusYear" class="price" style="display:none;">
                                <div class="pricelabel_bold_red">{{appSettings[3].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</div>
                                <span class="pricelabel_bold">{{Math.ceil(( appSettings[3].price / 12 ) * 10).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <div>Při roční platbě {{appSettings[9].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč</div>
                                <div>(2 měsíce zdarma)</div>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/business-rok?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-business-rok'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div id="BusMonth" class="price">
                                <span class="pricelabel_bold">{{appSettings[3].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/business-mesic?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-business-mesic'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div class="small_title"><br>Ceny jsou uvedeny bez DPH</div>
                        </div>
                    </div>
                    <div class="col-md-5 col-lg-3" style="padding-left: 7px;padding-right: 7px;min-width: 280px;">
                        <div class="item">
                            <div class="heading" style="margin-bottom: 1rem;">
                                <h3 class="businessHeader mycolor"><strong>PROFI</strong></h3>

                                <div class="features">
                                    <h4><span class="feature">do <strong>{{appSettings[4].creditVariant.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}}</strong></span> unikátních <br />návštěv za měsíc</h4>
                                </div>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně domén
                                <span class="businesstooltiptext font-weight-normal">Zobrazte notifikace na všech vašich stránkách a doménách.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Neomezeně notifikací
                                <span class="businesstooltiptext font-weight-normal">Zobrazte tolik notifikací, kolik vaše weby snesou.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Přizpůsobení notifikací
                                <span class="businesstooltiptext font-weight-normal">Nastavte si vlastní pravidla zobrazování a časování notifikací. Např. Zpoždění první notifikace.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Aktuální návštěvníci
                                <span class="businesstooltiptext font-weight-normal">
                                    Ukažte, jak to u vás žije a zobrazte množství lidí, kteří si prohlíží vaše stránky v reálném čase.
                                    Např. 137 návštěvníků si právě prohlíží tuto stránku.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední objednávky
                                <span class="businesstooltiptext font-weight-normal">Zobrazte reálné objednávky uskutečněné ve vašem e-shopu a motivujte ostatní k nákupu.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Poslední registrace
                                <span class="businesstooltiptext font-weight-normal">Zobrazte kontakty registrované z různých formulářů na webu. Např. webinář, stažení e-booku, zasílání newsletteru atd.</span>
                            </div>

                            <div class="businesstooltip businessItemGreen">
                                Souhrnné statistiky
                                <span class="businesstooltiptext font-weight-normal">
                                    Zobrazte celkové počty objednávek, registrací, návštěv nebo zobrazených stránek za vybrané časové období. Např. 268 návštěvníků si u nás nakoupilo za posledních 24 hodin.
                                </span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Recenze a hodnocení
                                <span class="businesstooltiptext font-weight-normal">Zobrazte nejlepší recenze z portálu Heuréka CZ/SK anebo Zboží.cz.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                TOP nabídky
                                <span class="businesstooltiptext font-weight-normal">Vytvořte si notifikaci s vlastním textem a odkazem. Propagujte novinky, slevy, články, soutěže atd.</span>
                            </div>
                            <div class="businesstooltip businessItemGreen">
                                Prioritní podpora
                                <span class="businesstooltiptext font-weight-normal">Když budete potřebovat pomoci nebo poradit, vyřešíme váš požadavek přednostně.</span>
                            </div>
                            <hr />
                            <p></p>
                            <div id="ProYear" class="price" style="display:none;">
                                <div class="pricelabel_bold_red">{{appSettings[4].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</div>
                                <span class="pricelabel_bold">{{Math.ceil(( appSettings[4].price / 12 ) * 10).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <div>Při roční platbě {{appSettings[10].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč</div>
                                <div>(2 měsíce zdarma)</div>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/profi-rok?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-profi-rok'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>
                            <div id="ProMonth" class="price">
                                <span class="pricelabel_bold">{{appSettings[4].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} Kč / měsíc</span>
                                <p></p>
                                <a v-bind:href="'https://app.cz/cenik/profi-mesic?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-profi-mesic'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">VYBRAT TARIF</a>
                            </div>

                            <div class="small_title"><br>Ceny jsou uvedeny bez DPH</div>
                        </div>
                    </div>
                </div>
                <div class="panel_subTitle_h1">
                    Potřebujete více než {{appSettings[4].creditVariant.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}} návštěvníků v tarifu?
                </div>
                <br />
                <p>
                    <a v-bind:href="'https://app.cz/cenik/enterprise?utm_source=app.app.cz&utm_medium=app-objednat&utm_campaign=app-enterprise'+linkData" target="_blank" class="btn btn-block btn-outline-business btn_new">KONTAKTUJTE NÁS</a>
                </p>

            </div>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

export default {
    data() {
        return {
            userUid: "none",
            RegEmail:"",
            Name: "",
            Surname: "",
            Company: "",
            Telephone: "",
            Ico: "",
            Dic: "",
            StreetACP: "",
            City: "",
            PostCode: "",
            linkData:"",
             appSettings: [{"paymentVersion":"Trial","creditVariant":25000,"price":0,"invoicePerriod":"month"},
                {"paymentVersion":"Start","creditVariant":5000,"price":390,"invoicePerriod":"month"},
                {"paymentVersion":"Basic","creditVariant":12000,"price":790,"invoicePerriod":"month"},
                {"paymentVersion":"Business","creditVariant":25000,"price":1490,"invoicePerriod":"month"},
                {"paymentVersion":"Profi","creditVariant":50000,"price":2490,"invoicePerriod":"month"},
                {"paymentVersion":"Enterprise","creditVariant":80000,"price":3490,"invoicePerriod":"month"},
                {"paymentVersion":"Trial","creditVariant":25000,"price":0,"invoicePerriod":"year"},
                {"paymentVersion":"Start","creditVariant":5000,"price":3900,"invoicePerriod":"year"},
                {"paymentVersion":"Basic","creditVariant":12000,"price":7900,"invoicePerriod":"year"},
                {"paymentVersion":"Business","creditVariant":25000,"price":14900,"invoicePerriod":"year"},
                {"paymentVersion":"Profi","creditVariant":50000,"price":24900,"invoicePerriod":"year"},
                {"paymentVersion":"Enterprise","creditVariant":80000,"price":34900,"invoicePerriod":"year"}
                ]
        }
    },
    methods: {
    },
    created() {
        Vue.cookie.set('EditCampaignID', null, 1);
        this.userUid = this.$store.state.AdminModule.adminUserKey;
        var that = this;
        $.ajax({
            type: "POST",
            url: "https://appi.app.cz:444/auth_status",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ session: Vue.cookie.get('session') })
        }).done(function (data) {
            if (data.result === 1) {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_user_profile",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (dataProfile) {
                    if (dataProfile.result === 1) {
                        that.RegEmail = dataProfile.RegEmail;
                        that.Name = dataProfile.Name;
                        that.Surname = dataProfile.Surname;
                        that.Company = dataProfile.Company;
                        that.Telephone = dataProfile.Telephone;
                        that.Ico = dataProfile.Ico;
                        that.Dic = dataProfile.Dic;
                        that.StreetACP = dataProfile.StreetACP;
                        that.City = dataProfile.City;
                        that.PostCode = dataProfile.PostCode;

                        that.linkData = (that.RegEmail !== "" && that.RegEmail !== undefined) ? "&fapi-form-email=" + that.RegEmail : "";
                        that.linkData += (that.Name !== "" && that.Name !== undefined) ? "&fapi-form-name=" + that.Name : "";
                        that.linkData += (that.Surname !== "" && that.Surname !== undefined) ? "&fapi-form-surname=" + that.Surname : "";
                        that.linkData += (that.Telephone !== "" && that.Telephone !== undefined) ? "&fapi-form-mobil=" + that.Telephone : "";
                        that.linkData += (that.StreetACP !== "" && that.StreetACP !== undefined) ? "&fapi-form-street=" + that.StreetACP : "";
                        that.linkData += (that.City !== "" && that.City !== undefined) ? "&fapi-form-city=" + that.City : "";
                        that.linkData += (that.PostCode !== "" && that.PostCode !== undefined) ? "&fapi-form-postcode=" + that.PostCode : "";
                        that.linkData += (that.Company !== "" && that.Company !== undefined) ? "&fapi-form-company=" + that.Company : "";
                        that.linkData += (that.Ico !== "" && that.Ico !== undefined) ? "&fapi-form-ic=" + that.Ico : "";
                        that.linkData += (that.Dic !== "" && that.Dic !== undefined) ? "&fapi-form-dic=" + that.Dic : "";

                    }
                })
            }
        })
        $.ajax({
            type: "POST",
            url: "https://appi.app.cz:444/get_appsettings",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ session: Vue.cookie.get('session') })
        }).done(function (data) {
            if (data.result === 1) {

                that.appSettings = data.appsettings;
            }
        });
    }
}

</script>