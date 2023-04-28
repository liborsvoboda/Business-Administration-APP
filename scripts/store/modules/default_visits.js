const state = {
    ShowDomainVisitCount: false,
    ShowCountHigherThan: 2,
    CycleShowing: true,
    MessageTextCz: "návštěvníků",
    MessageTextSk: "návštevníkov",
    MessageTextEn: "visitors",
};

const getters = {
    VISITCOUNT_ShowDomainVisitCount: state => { return state.ShowDomainVisitCount = false },
    VISITCOUNT_ShowCountHigherThan: state => { return state.ShowCountHigherThan = 2 },
    VISITCOUNT_CycleShowing: state => { return state.CycleShowing = true },
    VISITCOUNT_MessageTextCz: state => { return state.MessageTextCz = "návštěvníků" },
    VISITCOUNT_MessageTextSk: state => { return state.MessageTextSk = "návštevníkov" },
    VISITCOUNT_MessageTextEn: state => { return state.MessageTextEn = "visitors" },
};

export default {
    state,
    getters
}