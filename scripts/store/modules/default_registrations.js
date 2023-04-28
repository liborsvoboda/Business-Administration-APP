const state = {
    MessageTextCz: "se přihlásil/a k odběru novinek",
    MessageTextSk: "sa prihlásilo k odberu noviniek",
    MessageTextEn: "subscribed to the newsletter",
    ShowMaxLastReg: 20,
    ShowRegFromLastDays: 2,
    ShowWhenExistMinReg: 1,
    ShowAnonymEmails: true,
    ShowOwnReg: false,
    CycleShowing: true,
};

const getters = {
    LASTEVENTSREGISTRATIONS_MessageTextCz: state => { return state.MessageTextCz = "se přihlásil/a k odběru novinek" },
    LASTEVENTSREGISTRATIONS_MessageTextSk: state => { return state.MessageTextSk = "sa prihlásilo k odberu noviniek" },
    LASTEVENTSREGISTRATIONS_MessageTextEn: state => { return state.MessageTextEn = "subscribed to the newsletter" },
    LASTEVENTSREGISTRATIONS_ShowMaxLastReg: state => { return state.ShowMaxLastReg = 20 },
    LASTEVENTSREGISTRATIONS_ShowRegFromLastDays: state => { return state.ShowRegFromLastDays = 2 },
    LASTEVENTSREGISTRATIONS_ShowWhenExistMinReg: state => { return state.ShowWhenExistMinReg = 1 },
    LASTEVENTSREGISTRATIONS_ShowAnonymEmails: state => { return state.ShowAnonymEmails = true },
    LASTEVENTSREGISTRATIONS_ShowOwnReg: state => { return state.ShowOwnReg = false },
    LASTEVENTSREGISTRATIONS_CycleShowing: state => { return state.CycleShowing = true },
};

export default {
    state,
    getters
}