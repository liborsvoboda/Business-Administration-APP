const state = {
    adminUserKey: "none",
    adminUserEmail: null
};

const getters = {
    ADMINMODULE_adminUserKey: state => { return state.adminUserKey = null },
    ADMINMODULE_adminUserEmail: state => { return state.adminUserEmail = null }
};

export default {
    state,
    getters
}