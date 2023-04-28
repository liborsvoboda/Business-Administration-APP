import Vue from "vue";
import Vuex from "vuex";

import Heureka from "./modules/default_heureka";
import Zbozi from "./modules/default_zbozi";
import VisitCount from "./modules/default_visits";
import LastEventsOrders from "./modules/default_orders";
import LastEventsRegistrations from "./modules/default_registrations";
import Statistics from "./modules/default_statistics";
import CampaignAdaptation from "./modules/default_campaignAdaptation";
import AdminModule from "./modules/default_admin";
import OwnAppi from "./modules/default_ownAppi";

Vue.use(Vuex);

export const store = new Vuex.Store({
    state: {
        languageList:["cs","sk","en"],
        clipBoardRules:[],
        clipBoardUrlsIn: [],
        clipBoardUrlsOut: [],
        CampaignData: [],
        AllCampaignsData: [],
        SelectedMessages: [],
        CampaignName: "",
        selectedLanguage: "cs",
        selectedDomain: "none",
        ignoreDomain: false,
        heurekaAPIkey: "none",
        zboziAPIkey: "none",
        FinalValidation: [],
        CaptureRuleObj: ['none'],
        CapturedUrlsObjIn: [[]],
        CapturedUrlsObjOut: [[]],
        CaptureRuleReg: ['none'],
        CapturedUrlsRegIn: [[]],
        CapturedUrlsRegOut: [[]],
        CaptureRuleStat: ['none'],
        CapturedUrlsStatIn: [[]],
        CapturedUrlsStatOut: [[]],
        ShownRule: ['none'],
        ShownUrlsIn: [[]],
        ShownUrlsOut: [[]],
        clipBoardParam: '',
        OwnAppiIcons: ["<svg fill='#813EEF' id='BellOutline' width='50' height='50' viewBox='0 0 24 24' xmlns='xmlns=&quot;http://www.w3.org/2000/svg&quot;'><path d='M16,17H7V10.5C7,8 9,6 11.5,6C14,6 16,8 16,10.5M18,16V10.5C18,7.43 15.86,4.86 13,4.18V3.5A1.5,1.5 0 0,0 11.5,2A1.5,1.5 0 0,0 10,3.5V4.18C7.13,4.86 5,7.43 5,10.5V16L3,18V19H20V18M11.5,22A2,2 0 0,0 13.5,20H9.5A2,2 0 0,0 11.5,22Z'></path></svg>",
            "<svg fill='#813EEF' id='BellOutline' width='50' height='50' viewBox='0 0 24 24' xmlns='xmlns=&quot;http://www.w3.org/2000/svg&quot;'><path d='M16,17H7V10.5C7,8 9,6 11.5,6C14,6 16,8 16,10.5M18,16V10.5C18,7.43 15.86,4.86 13,4.18V3.5A1.5,1.5 0 0,0 11.5,2A1.5,1.5 0 0,0 10,3.5V4.18C7.13,4.86 5,7.43 5,10.5V16L3,18V19H20V18M11.5,22A2,2 0 0,0 13.5,20H9.5A2,2 0 0,0 11.5,22Z'></path></svg>",
            "<svg fill='#813EEF' id='BellOutline' width='50' height='50' viewBox='0 0 24 24' xmlns='xmlns=&quot;http://www.w3.org/2000/svg&quot;'><path d='M16,17H7V10.5C7,8 9,6 11.5,6C14,6 16,8 16,10.5M18,16V10.5C18,7.43 15.86,4.86 13,4.18V3.5A1.5,1.5 0 0,0 11.5,2A1.5,1.5 0 0,0 10,3.5V4.18C7.13,4.86 5,7.43 5,10.5V16L3,18V19H20V18M11.5,22A2,2 0 0,0 13.5,20H9.5A2,2 0 0,0 11.5,22Z'></path></svg>",
            "<svg fill='#813EEF' id='BellOutline' width='50' height='50' viewBox='0 0 24 24' xmlns='xmlns=&quot;http://www.w3.org/2000/svg&quot;'><path d='M16,17H7V10.5C7,8 9,6 11.5,6C14,6 16,8 16,10.5M18,16V10.5C18,7.43 15.86,4.86 13,4.18V3.5A1.5,1.5 0 0,0 11.5,2A1.5,1.5 0 0,0 10,3.5V4.18C7.13,4.86 5,7.43 5,10.5V16L3,18V19H20V18M11.5,22A2,2 0 0,0 13.5,20H9.5A2,2 0 0,0 11.5,22Z'></path></svg>",
            "<svg fill='#813EEF' id='BellOutline' width='50' height='50' viewBox='0 0 24 24' xmlns='xmlns=&quot;http://www.w3.org/2000/svg&quot;'><path d='M16,17H7V10.5C7,8 9,6 11.5,6C14,6 16,8 16,10.5M18,16V10.5C18,7.43 15.86,4.86 13,4.18V3.5A1.5,1.5 0 0,0 11.5,2A1.5,1.5 0 0,0 10,3.5V4.18C7.13,4.86 5,7.43 5,10.5V16L3,18V19H20V18M11.5,22A2,2 0 0,0 13.5,20H9.5A2,2 0 0,0 11.5,22Z'></path></svg>"
        ]
    },
    getters: {
    
    },
    modules: {
        Heureka,
        Zbozi,
        VisitCount,
        LastEventsOrders,
        LastEventsRegistrations,
        Statistics,
        CampaignAdaptation,
        AdminModule,
        OwnAppi
    }
});