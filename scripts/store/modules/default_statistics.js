const state = {
    SelectedStatsVariant: "visitor",
    ShowStatsFromLastDays: 7,
    ShowStatsDomainVisitCount: false,
    ShowCountHigherThan: 5,
    CycleShowing: true,
    MessageTextCz: "lidí",
    MessageTextSk: "ľudí",
    MessageTextEn: "people",
};

const getters = {
    STATISTICS_SelectedStatsVariant: state => { return state.SelectedStatsVariant = "visitor" },
    STATISTICS_ShowStatsFromLastDays: state => { return state.ShowStatsFromLastDays = 7 },
    STATISTICS_ShowStatsDomainVisitCount: state => { return state.ShowStatsDomainVisitCount = true },
    STATISTICS_ShowCountHigherThan: state => { return state.ShowCountHigherThan = 5 },
    STATISTICS_CycleShowing: state => { return state.CycleShowing = true },
    STATISTICS_MessageTextCz: state => { return state.MessageTextCz = "lidí" },
    STATISTICS_MessageTextSk: state => { return state.MessageTextSk = "ľudí" },
    STATISTICS_MessageTextEn: state => { return state.MessageTextEn = "people" },
};

export default {
    state,
    getters
}