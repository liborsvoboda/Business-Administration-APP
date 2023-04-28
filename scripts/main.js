import 'bootstrap/dist/js/bootstrap';
import 'simpler-sidebar/dist/jquery.simpler-sidebar';
import './right_menu_title_page';

import '../styles/site.scss';

import Vue from 'vue';
import VueI18n from 'vue-i18n';
import VueCookie from 'vue-cookie';

import VueRouter from 'vue-router';
import router from './router';
import App from './components/distributor/App.vue';

import { store } from "./store/store";

import layoutTrial from './components/layout-trial.vue';
import layoutPixelAlert from './components/layout-pixel-alert.vue';
import layoutLoginStatus from './components/layout-login-status.vue';
import layoutCreditStatus from './components/layout-credit-status.vue';
import layoutCampaignStatus from './components/layout-campaign-status.vue';
import layoutHeurekaStatus from './components/layout-heureka-status.vue';
import layoutZboziStatus from './components/layout-zbozi-status.vue';

import layoutAdmin from './components/layout-admin.vue';
import layoutAbTesting from './components/layout-abTesting.vue';

import langCs from './store/langCs';
import langEn from './store/langEn';
import langValidcs from "vee-validate/dist/locale/cs";
import langValiden from "vee-validate/dist/locale/en";

import localeSwitcher from './components/locale-switcher.vue';

Vue.config.devtools = true;
Vue.config.productionTip = false;

Vue.use(VueI18n);
Vue.use(VueCookie);
Vue.use(VueRouter);

const locale = Vue.cookie.get('locale') || 'cs';

const messages = {
    en: langEn,
    cs: langCs
};


const i18n = new VueI18n({
    locale: locale,
    messages
});

new Vue({
    router,
    beforeCreate() {
        var that = this;
        if (Vue.cookie.get('session') != null && Vue.cookie.get('session') != 'null') {
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/auth_status",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    if (window.location.pathname.toLowerCase() == "/") {
                        that.$router.push('/');
                    }
                    if (window.location.pathname.toLowerCase() == "/newcampaign") {
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/newabtest") {
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/pixelinstallation") {
                        that.$router.push('/PixelInstallation');
                    }
                    if (window.location.pathname.toLowerCase() == "/campaigns") {
                        that.$router.push('/Campaigns');
                    }
                    if (window.location.pathname.toLowerCase() == "/heurekaapi") {
                        that.$router.push('/HeurekaApi');
                    }
                    if (window.location.pathname.toLowerCase() == "/zboziapi") {
                        that.$router.push('/ZboziApi');
                    }
                    if (window.location.pathname.toLowerCase() == "/settings") {
                        that.$router.push('/Settings');
                    }
                    if (window.location.pathname.toLowerCase() == "/abtesting") {
                        that.$router.push('/AbTesting');
                    }
                    if (window.location.pathname.toLowerCase() == "/abgraphs") {
                        //that.$router.push('/AbGraphs');
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/registration") {
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/registrationmonth") {
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/resetpassword") {
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/businessplanselection") {
                        that.$router.push('/BusinessPlanSelection');
                    }
                    if (window.location.pathname.toLowerCase() == "/businessexternal") {
                        that.$router.push('/BusinessExternal');
                    }
                    if (window.location.pathname.toLowerCase() == "/shoptet") {
                        that.$router.push({ path: that.$route.fullPath });
                    }
                    if (window.location.pathname.toLowerCase() == "/adminclientlist") {
                        that.$router.push('/AdminClientList');
                    }
                    if (window.location.pathname.toLowerCase() == "/admincredits") {
                        that.$router.push('/AdminCredits');
                    }
                    if (window.location.pathname.toLowerCase() == "/adminscripts") {
                        that.$router.push('/AdminScripts');
                    }
                    if (window.location.pathname.toLowerCase() == "/adminndictionary") {
                        that.$router.push('/AdminNDictionary');
                    }
                    if (window.location.pathname.toLowerCase() == "/login") {
                        that.$router.push('/Login');
                    }
                } else {
                    switch (window.location.pathname.toLowerCase()) {
                        case "/registration":
                            that.$router.push({ path: that.$route.fullPath });
                            break;
                        case "/registrationmonth":
                            that.$router.push({ path: that.$route.fullPath });
                            break;
                        case "/resetpassword":
                            that.$router.push({ path: that.$route.fullPath });
                            break;
                        case "/businessplanselection":
                            that.$router.push('/BusinessPlanSelection');
                            break;
                        case "/businessexternal":
                            that.$router.push('/BusinessExternal');
                            break;
                        case "/shoptet":
                            that.$router.push({ path: that.$route.fullPath });
                            break;
                        case "/login":
                            //that.$router.push('/Login');
                            break;
                        default:
                            // that.$router.push({ path: '/Login', query: { 0: that.$route.fullPath } });
                            window.location.href = '/Login?0=' + that.$route.fullPath; 
                    }
                }
            })
        } else {
            switch (window.location.pathname.toLowerCase()) {
                case "/registration":
                    that.$router.push({ path: that.$route.fullPath });
                    break;
                case "/registrationmonth":
                    that.$router.push({ path: that.$route.fullPath });
                    break;
                case "/resetpassword":
                    that.$router.push({ path: that.$route.fullPath });
                    break;
                case "/businessplanselection":
                    that.$router.push('/BusinessPlanSelection');
                    break;
                case "/businessexternal":
                    that.$router.push('/BusinessExternal');
                    break;
                case "/shoptet":
                    that.$router.push({ path: that.$route.fullPath });
                    break;
                case "/login":
                    //that.$router.push('/Login');
                    break;
                default:
                   // that.$router.push({ path: '/Login', query: { 0: that.$route.fullPath } });
                    window.location.href = '/Login?0=' + that.$route.fullPath; 
            }
        }
     
        //console.log('routelog', this.$route.query);
    },
    el: '#cshtmlSection',
    i18n,
    store,
    render: h => h(App)
});

//disabled language selection
//new Vue({
//    el: '#localeSwitcherVue',
//    i18n,
//    render: h => h(localeSwitcher)
//});

var that = this;
if (Vue.cookie.get('session') != null && window.location.pathname.toLowerCase() != "/shoptet") {
    $.ajax({
        type: "POST",
        url: "https://appi.app.cz:444/auth_status",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ session: Vue.cookie.get('session') })
    }).done(function (data) {
        if (data.result === 1) {

            new Vue({
                el: '#layoutPixelAlertVue',
                i18n,
                store,
                render: h => h(layoutPixelAlert)
            });

            new Vue({
                el: '#layoutTrialVue',
                i18n,
                store,
                render: h => h(layoutTrial)
            });

            new Vue({
                el: '#layoutCampaignStatusVue',
                i18n,
                store,
                render: h => h(layoutCampaignStatus)
            });
            new Vue({
                el: '#layoutCreditStatusVue',
                i18n,
                store,
                render: h => h(layoutCreditStatus)
            });
            new Vue({
                el: '#layoutHeurekaStatusVue',
                i18n,
                store,
                render: h => h(layoutHeurekaStatus)
            });
            new Vue({
                el: '#layoutZboziStatusVue',
                i18n,
                store,
                render: h => h(layoutZboziStatus)
            });
            new Vue({
                el: '#layoutAdminVue',
                i18n,
                store,
                render: h => h(layoutAdmin)
            });
            new Vue({
                el: '#layoutAbTestingVue',
                i18n,
                store,
                render: h => h(layoutAbTesting)
            });
        }
    })
}
new Vue({
    el: '#layoutLoginStatusVue',
    i18n,
    store,
    render: h => h(layoutLoginStatus)
});

//module.hot.accept();