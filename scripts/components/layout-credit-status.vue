<template>
    <li class="nav-item" style="float:none;">
        <span class="credit_label">Kredit&nbsp;&nbsp;{{CreditCounts}} / {{CreditVariant}}</span>
        <i style="color:#7dc542; opacity:1; " class="fa fa-question-circle pointer"
           v-tooltip.right="{class: 'v-tooltip_visit mycolor', content: 'Tarif: '+PaymentVersion+'\nAktivní do: '+new Date(NextPayDate).toLocaleDateString('cs-CZ').replace(/\s+/g, '') }"></i>
    </li>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

export default {
	data() {
        return {
            adminAccess: false,
            userUid: "none",
            userEmail: null,
            CreditCounts: 0,
            CreditVariant:0,
            PaymentVersion: null,
            NextPayDate: null,
		}
	},

	methods: {
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
                        that.CreditCounts = dataCredit.CreditCounts;
                        that.CreditVariant = dataCredit.CreditVariant;
                        that.PaymentVersion = (dataCredit.PaymentVersion != "Trial") ? dataCredit.PaymentVersion : "Zkušební verze";
                        that.NextPayDate = dataCredit.NextPayDate;
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
                        that.CreditCounts = dataCredit.CreditCounts;
                        that.CreditVariant = dataCredit.CreditVariant;
                        that.PaymentVersion = (dataCredit.PaymentVersion != "Trial") ? dataCredit.PaymentVersion :"Zkušební verze";
                        that.NextPayDate = dataCredit.NextPayDate;
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

	beforeCreate(){
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
                that.CreditCounts = dataCredit.CreditCounts;
                that.CreditVariant = dataCredit.CreditVariant;
                that.PaymentVersion = (dataCredit.PaymentVersion != "Trial") ? dataCredit.PaymentVersion : "Zkušební verze";
                that.NextPayDate = dataCredit.NextPayDate;
            }
        });
    }           
}
</script>