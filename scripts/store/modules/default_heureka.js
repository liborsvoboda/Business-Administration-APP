const state = {
    ShowRevFromLastDays: 30,
    ShowRevStarsHigherThan: 4,
    ShowWhenExistMinRev: 3,
    CycleShowing: false
};

const getters = {
    HEUREKA_ShowRevFromLastDays: state => { return state.ShowRevFromLastDays = 30 },
    HEUREKA_ShowRevStarsHigherThan: state => { return state.ShowRevStarsHigherThan = 4 },
    HEUREKA_ShowWhenExistMinRev: state => { return state.ShowWhenExistMinRev = 3 },
    HEUREKA_CycleShowing: state => { return state.CycleShowing = false },
};

export default {
    state,
    getters
}