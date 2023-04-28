const state = {
    MessageTextCz: "má dokončenou objednávku",
    MessageTextSK: "má dokončenú objednávku",
    MessageTextEn: "has completed the order",
    ShowMaxLastOrders: 20,
    ShowOrdersFromLastDays: 2,
    ShowWhenExistMinOrders: 1,
    ShowNewOrdersAfterReloadPage: true,
    ShowAnonymEmails: true,
    ShowOwnOrders: false,
    CycleShowing: true,
};

const getters = {
    LASTEVENTSORDERS_MessageTextCz: state => { return state.MessageTextCz = "má dokončenou objednávku" },
    LASTEVENTSORDERS_MessageTextSk: state => { return state.MessageTextSk = "má dokončenú objednávku" },
    LASTEVENTSORDERS_MessageTextEn: state => { return state.MessageTextEn = "has completed the order" },
    LASTEVENTSORDERS_ShowMaxLastOrders: state => { return state.ShowMaxLastOrders = 20 },
    LASTEVENTSORDERS_ShowOrdersFromLastDays: state => { return state.ShowOrdersFromLastDays = 2 },
    LASTEVENTSORDERS_ShowWhenExistMinOrders: state => { return state.ShowWhenExistMinOrders = 1 },
    LASTEVENTSORDERS_ShowAnonymEmails: state => { return state.ShowAnonymEmails = true },
    LASTEVENTSORDERS_ShowNewOrdersAfterReloadPage: state => { return state.ShowNewOrdersAfterReloadPage = true },
    LASTEVENTSORDERS_ShowOwnOrders: state => { return state.ShowOwnOrders = false },
    LASTEVENTSORDERS_CycleShowing: state => { return state.CycleShowing = true },
};

export default {
    state,
    getters
}