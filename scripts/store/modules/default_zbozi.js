const state = {
    ShowZboziShopFromLastDays: 365,
    ShowZboziProductFromLastDays: 365,
    ShowZboziStarsHigherThan: 4,
    ShowWhenExistMinZboziShop: 3,
    ShowWhenExistMinZboziProduct: 3,
    CycleShowingShop: false,
    CycleShowingProduct: false,
    SelectedZboziVariant: "shop",
    ZboziShopActive: true,
    ZboziProductActive: false

};

const getters = {
    ZBOZI_ShowZboziShopFromLastDays: state => { return state.ShowZboziShopFromLastDays = 365 },
    ZBOZI_ShowZboziProductFromLastDays: state => { return state.ShowZboziProductFromLastDays = 365 },
    ZBOZI_ShowZboziStarsHigherThan: state => { return state.ShowZboziStarsHigherThan = 4 },
    ZBOZI_ShowWhenExistMinZboziShop: state => { return state.ShowWhenExistMinZboziShop = 3 },
    ZBOZI_ShowWhenExistMinZboziProduct: state => { return state.ShowWhenExistMinZboziProduct = 3 },
    ZBOZI_CycleShowingShop: state => { return state.CycleShowingShop = false },
    ZBOZI_CycleShowingProduct: state => { return state.CycleShowingProduct = false },
    ZBOZI_SelectedZboziVariant: state => { return state.SelectedZboziVariant = "shop" },
    ZBOZI_ZboziShopActive: state => { return state.ZboziShopActive = true },
    ZBOZI_ZboziProductActive: state => { return state.ZboziProductActive = false }
};

export default {
    state,
    getters
}