<template>
    <div v-if="(DaysLeft < 5 || Trial)">
        <div class="container-fluid lista_container" v-bind:class="{ 'lista_container_green': (!Trial && DaysLeft > 0) }">
            <div class="row justify-content-center">
                <div class="col-12">
                    <div class="d-flex justify-content-between align-items-center">
                        <div>{{trialText}} {{ DaysToPay }}</div>
                        <div v-if="Trial">
                            <a class="btn btn-main-primary btn_order btn-sm" v-on:click="Order" :class="{disabled: userUid != 'none'}">OBJEDNAT&nbsp;&nbsp;&nbsp; <i class="fas fa-shopping-basket"></i></a>
                        </div>
                        <div v-if="(!Trial && DaysLeft <= 0)">
                            <a href="https://app.cz/kontakt/?utm_source=app.app.cz&utm_medium=app-lista&utm_campaign=app-kontakt-vyprsel-tarif" target="_blank" class="btn btn-main-primary btn_order btn-sm" :class="{disabled: userUid != 'none'}">KONTAKTOVAT</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div v-else-if="(creditCounts <= 0)">
        <div class="container-fluid lista_container" v-bind:class="{ 'lista_container_orange': (creditCounts <= 0) }">
            <div class="row justify-content-center">
                <div class="col-12">
                    <div class="d-flex justify-content-between align-items-center">
                        <div>Už nemáte žádné kredity. Notifikace se nezobrazují. Zdá se, že potřebujete přejít na vyšší tarif.</div>
                        <div>
                            <a class="btn btn-main-primary btn_order btn-sm" v-on:click="Order" :class="{disabled: userUid != 'none'}">OBJEDNAT&nbsp;&nbsp;&nbsp; <i class="fas fa-shopping-basket"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

    export default {
        data() {
            return {
                RegisterDate: null,
                DaysToPay: 0,
                DaysLeft: null,
                Trial: null,
                trialText: "Vaše zkušební verze",
                adminAccess: false,
                userUid: "none",
                userEmail: null,
                creditCounts: null

            }
        },
        methods: {
            date_diff_indays(date2, date1) {
                var dt1 = date1;
                var dt2 = date2;
                return Math.floor((Date.UTC(dt2.getFullYear(), dt2.getMonth(), dt2.getDate()) - Date.UTC(dt1.getFullYear(), dt1.getMonth(), dt1.getDate())) / (1000 * 60 * 60 * 24));
            },
            IsSafari() {
                if (navigator.userAgent.search("Safari") >= 0 && navigator.userAgent.search("Chrome") < 0) {
                    return true;
                }
                else return false;
            },
            Order(){
                if (this.userUid == "none") {
                    window.location.href = "/BusinessPlanSelection";
                }
            },
            fn_reloadCredit() {
                this.userUid = this.$store.state.AdminModule.adminUserKey;
                var that = this;
                if (that.userUid != "none") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/user_credits",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                    }).done(function (dataCredit) {
                        if (dataCredit.result === 1) {
                            that.RegisterDate = dataCredit.RegisterDate;
                            that.Trial = dataCredit.Trial;
                            that.creditCounts = dataCredit.CreditCounts

                            that.DaysLeft = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());
                            if (!that.Trial && that.DaysLeft < 5) {
                                that.trialText = "Vaše placená verze";
                            } else {
                                that.trialText = "Vaše zkušební verze";
                            }

                            if (that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date()) >= 0) {
                                that.DaysToPay = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());


                                switch (that.DaysToPay) {
                                    case 0:
                                        that.DaysToPay = "končí dnes";
                                        break;
                                    case 1:
                                        that.DaysToPay = "končí za " + that.DaysToPay + " den";
                                        break;
                                    case 2: case 3: case 4:
                                        that.DaysToPay = "končí za " + that.DaysToPay + " dny";
                                        break;
                                    default:
                                        that.DaysToPay = "končí za " + that.DaysToPay + " dní";
                                }

                                if (!that.Trial && that.DaysToPay < 5) {
                                    that.DaysToPay += " a bude uhrazena automaticky nebo ručně dle vybrané platební metody";
                                }

                            } else {
                                if (that.Trial) {
                                    that.trialText = "Vaše zkušební verze";
                                    that.DaysToPay = 'skončila. Přihlásit se můžete ještě 1 rok, ale notifikace se již nezobrazují. Nechte objednávky růst a objednejte si placený tarif';
                                } else {
                                    that.trialText = "";
                                    that.DaysToPay = 'Váš placený tarif skončil a bude prodloužen až po úhradě faktury. Vidíte-li tuto zprávu, přestože máte zaplaceno, kontaktujte nás.';
                                }
                            }
                        }
                    });
                } else {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/credits",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session') })
                    }).done(function (dataCredit) {
                        if (dataCredit.result === 1) {
                            that.RegisterDate = dataCredit.RegisterDate;
                            that.Trial = dataCredit.Trial;
                            that.creditCounts = dataCredit.CreditCounts;

                            that.DaysLeft = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());
                            if (!that.Trial && that.DaysLeft < 5) {
                                that.trialText = "Vaše placená verze";
                            } else {
                                that.trialText = "Vaše zkušební verze";
                            }

                            if (that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date()) >= 0) {
                                that.DaysToPay = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());

                                switch (that.DaysToPay) {
                                    case 0:
                                        that.DaysToPay = "končí dnes";
                                        break;
                                    case 1:
                                        that.DaysToPay = "končí za " + that.DaysToPay + " den";
                                        break;
                                    case 2: case 3: case 4:
                                        that.DaysToPay = "končí za " + that.DaysToPay + " dny";
                                        break;
                                    default:
                                        that.DaysToPay = "končí za " + that.DaysToPay + " dní";
                                }

                                if (!that.Trial && that.DaysToPay < 5) {
                                    that.DaysToPay += " a bude uhrazena automaticky nebo ručně dle vybrané platební metody";
                                }

                            } else {
                               
                                if (!that.IsSafari()) {
                                    if (that.Trial) {
                                        that.trialText = "Vaše zkušební verze";
                                        that.DaysToPay = 'skončila. Přihlásit se můžete ještě 1 rok, ale notifikace se již nezobrazují. Nechte objednávky růst a objednejte si placený tarif';
                                    } else {
                                        that.trialText = "";
                                        that.DaysToPay = 'Váš placený tarif skončil a bude prodloužen až po úhradě faktury. Vidíte-li tuto zprávu, přestože máte zaplaceno, kontaktujte nás.';
                                    }
                                }
                              
                            }
                        }
                    });
                }
            }
        },

        computed: {
            checkadminUserKey() {
                return this.$store.state.AdminModule.adminUserKey;
            },
        },
        watch: {
            checkadminUserKey(value) {
                this.fn_reloadCredit();
            },
        },
        beforeCreate() {
		},

        created() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/credits",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (dataCredit) {
                if (dataCredit.result === 1) {
                    that.RegisterDate = dataCredit.RegisterDate;
                    that.Trial = dataCredit.Trial;
                    that.creditCounts = dataCredit.CreditCounts;

                    that.DaysLeft = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());
                    if (!that.Trial && that.DaysLeft < 5) {
                        that.trialText = "Vaše placená verze";
                    } else {
                        that.trialText = "Vaše zkušební verze";
                    }

                    if (that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date()) >= 0) {
                        that.DaysToPay = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());

                        switch (that.DaysToPay) {
                            case 0:
                                that.DaysToPay = "končí dnes";
                                break;
                            case 1:
                                that.DaysToPay = "končí za " + that.DaysToPay + " den";
                                break;
                            case 2: case 3: case 4:
                                that.DaysToPay = "končí za " + that.DaysToPay + " dny";
                                break;
                            default:
                                that.DaysToPay = "končí za " + that.DaysToPay + " dní";
                        }

                        if (!that.Trial && that.DaysToPay < 5) {
                            that.DaysToPay += " a bude uhrazena automaticky nebo ručně dle vybrané platební metody";
                        }
                        
                    } else {
                        if (that.Trial) {
                            that.trialText = "Vaše zkušební verze";
                            that.DaysToPay = 'skončila. Přihlásit se můžete ještě 1 rok, ale notifikace se již nezobrazují. Nechte objednávky růst a objednejte si placený tarif';
                        } else {
                            that.trialText = "";
                            that.DaysToPay = 'Váš placený tarif skončil a bude prodloužen až po úhradě faktury. Vidíte-li tuto zprávu, přestože máte zaplaceno, kontaktujte nás.';
                        }
                    }
                }
            });
        }
    }
</script>