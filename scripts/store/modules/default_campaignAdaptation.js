const state = {
    HiddenAppiOnMobile: false,
    ShowUpOnMobile: false,
    HiddenAppiOnComputer: false,
    ShowUpOnComputer: false,
    AppiPosition: "left",
    AppiPositionOnMobile: "left",
    AppiPositionCenter: false,
    AppiPositionOnMobileCenter: false,
    MobDelayBeforeFirstAppi: 4,
    MobAppiShowTime: 5,
    MobDelayBetweenAppi: 15,
    PcDelayBeforeFirstAppi: 2,
    PcAppiShowTime: 7,
    PcDelayBetweenAppi: 5,
    PcSpeedAppi:5,
    MobSpeedAppi:7
};

const getters = {
    CAMPAIGNADAPTATION_HiddenAppiOnMobile: state => { return state.HiddenAppiOnMobile = false },
    CAMPAIGNADAPTATION_ShowUpOnMobile: state => { return state.ShowUpOnMobile = false },
    CAMPAIGNADAPTATION_HiddenAppiOnComputer: state => { return state.HiddenAppiOnComputer = false },
    CAMPAIGNADAPTATION_ShowUpOnComputer: state => { return state.ShowUpOnComputer = false },
    CAMPAIGNADAPTATION_AppiPosition: state => { return state.AppiPosition = "left" },
    CAMPAIGNADAPTATION_AppiPositionOnMobile: state => { return state.AppiPositionOnMobile = "left" },
    CAMPAIGNADAPTATION_AppiPositionCenter: state => { return state.AppiPositionCenter = false },
    CAMPAIGNADAPTATION_AppiPositionOnMobileCenter: state => { return state.AppiPositionOnMobileCenter = false },
    CAMPAIGNADAPTATION_MobDelayBeforeFirstAppi: state => { return state.MobDelayBeforeFirstAppi = 4 },
    CAMPAIGNADAPTATION_MobAppiShowTime: state => { return state.MobAppiShowTime = 5 },
    CAMPAIGNADAPTATION_MobDelayBetweenAppi: state => { return state.MobDelayBetweenAppi = 15 },
    CAMPAIGNADAPTATION_PcDelayBeforeFirstAppi: state => { return state.PcDelayBeforeFirstAppi = 2 },
    CAMPAIGNADAPTATION_PcAppiShowTime: state => { return state.PcAppiShowTime = 7 },
    CAMPAIGNADAPTATION_PcDelayBetweenAppi: state => { return state.PcDelayBetweenAppi = 5 },
    CAMPAIGNADAPTATION_PcSpeedAppi: state => { return state.PcSpeedAppi = 5 },
    CAMPAIGNADAPTATION_MobSpeedAppi: state => { return state.MobSpeedAppi = 7 },
};

export default {
    state,
    getters
}