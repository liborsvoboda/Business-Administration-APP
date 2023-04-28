import VueRouter from 'vue-router';
import { store }  from "./store/store";


import login from './components/login.vue';
import index from './components/index.vue';
import settings from './components/settings.vue';
import pixelInstallation from './components/pixelInstallation.vue';
import heurekaApi from './components/heurekaApi.vue';
import zboziApi from './components/zboziApi.vue';
import registration from './components/registration.vue';
import registrationMonth from './components/registrationMonth.vue';
import resetPassword from './components/resetPassword.vue';
import newCampaign from './components/newCampaign.vue';
import newAbTest from './components/newAbTest.vue';
import campaigns from './components/campaigns.vue';
import abtesting from './components/abTesting.vue';
import abgraphs from './components/abGraphs.vue';
import businessPlanSelection from './components/businessPlanSelection.vue';
import businessExternal from './components/businessExternal.vue';
import shoptet from './components/shoptet.vue';
import NProgress from 'nprogress';

import adminClientList from './components/adminCIientList.vue';
import adminCredits from './components/adminCredits.vue';
import adminScripts from './components/adminScripts.vue';
import adminNDictionary from './components/adminNDictionary.vue';


const router = new VueRouter({
    mode: 'history',
    routes: [
        { path: '/Login', component: login, name: 'login', store: store, props: true },
        { path: '/', component: index, name: 'index' },
        { path: '/NewCampaign', component: newCampaign, store: store, name: 'newCampaign' },
        { path: '/NewAbTest', component: newAbTest, store: store, name: 'newAbTest' },
        { path: '/PixelInstallation', component: pixelInstallation, name: 'pixelInstallation' },
        { path: '/Campaigns', component: campaigns, store: store, name: 'campaigns' },
        { path: '/AbTesting', component: abtesting, store: store, name: 'abtesting' },
        { path: '/AbGraphs', component: abgraphs, store: store, name: 'abgraphs', props: true },
        { path: '/HeurekaApi', component: heurekaApi, name: 'heurekaApi' },
        { path: '/ZboziApi', component: zboziApi, name: 'zboziApi' },
        { path: '/Settings', component: settings, name: 'settings' },
        { path: '/Registration', component: registration, name: 'registration', props: true },
        { path: '/RegistrationMonth', component: registrationMonth, name: 'registrationMonth', props: true },
        { path: '/ResetPassword', component: resetPassword, name: 'resetPassword', props: true },
        { path: '/BusinessPlanSelection', component: businessPlanSelection, name: 'businessPlanSelection' },
        { path: '/BusinessExternal', component: businessExternal, name: 'businessExternal' },
        { path: '/AdminClientList', component: adminClientList, store: store, name: 'adminClientList' },
        { path: '/AdminCredits', component: adminCredits, store: store, name: 'adminCredits' },
        { path: '/AdminScripts', component: adminScripts, store: store, name: 'adminScripts' },
        { path: '/AdminNDictionary', component: adminNDictionary, store: store, name: 'adminNDictionary' },
        { path: '/Shoptet', component: shoptet, name: 'shoptet', props: true  }

    ]
});

router.beforeResolve((to, from, next) => {
    if (to.name) {
        NProgress.start()
    }
    next()
});

router.afterEach((to, from) => {
    NProgress.done()
});

export default router;