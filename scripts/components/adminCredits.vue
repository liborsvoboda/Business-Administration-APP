<template>
    <div class="container" v-show="authUser=='true' && adminAccount">
        <div class="row justify-content-center">
            <div class="col-lg-11 col-xl-9">
                <h2 class="py-3 pt-5 pb-4 text-center">Váš účet</h2>

                <div class="list-group mt-2">
                    <form @submit.prevent="validateForm('Credits')" data-vv-scope="Credits">
                        <h2 class="list-group-item group_item_blue bold py-3">
                            NASTAVENÍ KLIENTA
                        </h2>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2">
                                    <input type="text" placeholder="a_box" v-on:input="validateForm('Credits')" v-model="Credits.a_box" name="a_box" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('Credits.a_box') }" />
                                    <span v-if="errors.has('Credits.a_box')" class="invalid-feedback">{{ errors.first('Credits.a_box') }}</span>
                                </div>
                                <div class="col-md-6 py-2">
                                    <input type="text" placeholder="a_cha" v-on:input="validateForm('Credits')" v-model="Credits.a_cha" name="a_cha" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('Credits.a_cha') }" />
                                    <span v-if="errors.has('Credits.a_cha')" class="invalid-feedback">{{ errors.first('Credits.a_cha') }}</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 py-2">
                                    <div class="text-center">Vyberte typ platby:</div>
                                    <select v-model="Credits.InvoicePeriod" v-on:change="SelectCreditCount()" style="max-width: 100%;" name="InvoicePeriod" v-validate="{required: true}" class="form-control" :class="{ 'is-invalid': errors.has('Credits.InvoicePeriod') }">
                                        <option disabled="disabled" value="none">Vyberte</option>
                                        <option value="month">Měsíční</option>
                                        <option value="year">Roční</option>
                                    </select>
                                    <span v-if="errors.has('Credits.InvoicePeriod')" class="invalid-feedback">{{ errors.first('Credits.InvoicePeriod') }}</span>
                                </div>

                                <div class="col-md-6 py-2">
                                    <div class="text-center">Vyberte tarif:</div>
                                    <select v-model="Credits.PaymentVersion" v-on:change="SelectCreditCount();" style="max-width: 100%;" name="PaymentVersion" v-validate="{required: true}" class="form-control" :class="{ 'is-invalid': errors.has('Credits.PaymentVersion') }">
                                        <option disabled="disabled" value="none">Vyberte</option>
                                        <option value="Trial">Trial</option>
                                        <option value="Start">Start</option>
                                        <option value="Basic">Basic</option>
                                        <option value="Business">Business</option>
                                        <option value="Profi">Profi</option>
                                        <option value="Enterprise">Enterprise</option>
                                    </select>
                                    <span v-if="errors.has('Credits.PaymentVersion')" class="invalid-feedback">{{ errors.first('Credits.PaymentVersion') }}</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2" style="top: 10px;">
                                    Následující platební termín
                                </div>
                                <div class="col-md-6 py-2 text-right">
                                    <datepicker :minimumView="'day'" :maximumView="'day'" :format="'yyyy-MM-dd'" v-on:input="validateForm('Credits')" v-model="Credits.NextPayDate" :language="dpcs" input-class="form-control form_control_set" style="display: initial;"></datepicker>
                                </div>
                            </div>
                        </div>
                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2" style="top: 10px;">
                                    Následující Credit termín
                                </div>
                                <div class="col-md-6 py-2 text-right">
                                    <datepicker :minimumView="'day'" :maximumView="'day'" :format="'yyyy-MM-dd'" v-on:input="validateForm('Credits')" v-model="Credits.CreditNextPayDate" :language="dpcs" input-class="form-control form_control_set" style="display: initial;"></datepicker>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="d-flex flex-row justify-content-between align-items-center pt-2">
                                <div>Trial režim</div>
                                <div class="noselect">
                                    <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                    <button type="button" class="btn btn-toggle" :class="{active: Credits.Trial}" v-on:click="Credits.Trial = !Credits.Trial" data-toggle="button" aria-pressed="false" autocomplete="off">
                                        <div class="handle"></div>
                                    </button>
                                    &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="d-flex flex-row justify-content-between align-items-center pt-2">
                                <div>Obchodník</div>
                                <div class="noselect" :disabled="(adminGroupId !== 999)">
                                    <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                    <button type="button" class="btn btn-toggle" :disabled="(adminGroupId !== 999)" :class="{active: Credits.isAdmin}" v-on:click="Credits.isAdmin = !Credits.isAdmin" data-toggle="button" aria-pressed="false" autocomplete="off">
                                        <div class="handle"></div>
                                    </button>
                                    &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="d-flex flex-row justify-content-between align-items-center pt-2">
                                <div>Povolit API TopNabídek</div>
                                <div class="noselect" :disabled="(adminGroupId !== 999)">
                                    <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                    <button type="button" class="btn btn-toggle" :disabled="(adminGroupId !== 999)" :class="{active: Credits.topVariablesAllowed}" v-on:click="Credits.topVariablesAllowed = !Credits.topVariablesAllowed" data-toggle="button" aria-pressed="false" autocomplete="off">
                                        <div class="handle"></div>
                                    </button>
                                    &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="d-flex flex-row justify-content-between align-items-center pt-2">
                                <div>Povolit AB Testy</div>
                                <div class="noselect" :disabled="(adminGroupId !== 999)">
                                    <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                    <button type="button" class="btn btn-toggle" :disabled="(adminGroupId !== 999)" :class="{active: Credits.abTestingAllowed}" v-on:click="Credits.abTestingAllowed = !Credits.abTestingAllowed" data-toggle="button" aria-pressed="false" autocomplete="off">
                                        <div class="handle"></div>
                                    </button>
                                    &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2" style="top: 10px;">
                                    GroupId
                                </div>
                                <div class="col-md-6 py-2 text-right">
                                    <input type="text" :disabled="(adminGroupId !== 999)" v-model="Credits.groupId" v-on:input="validateForm('Credits')" v-validate="{required: false,numeric:true, min_value:0, max_value: 999}" name="GroupId" class="form-control form_control_set_width_2 text-right" :class="{ 'is-invalid': errors.has('Credits.GroupId') }" style="display: initial;" />
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2" style="top: 10px;">
                                    Počet dostupných kreditů
                                </div>
                                <div class="col-md-6 py-2 text-right">
                                    <input type="text" v-model="Credits.CreditCounts" v-on:input="validateForm('Credits')" v-validate="{required: true,numeric:true, min_value:0, max_value: 9999999}" name="CreditCounts" class="form-control form_control_set_width_2 text-right" :class="{ 'is-invalid': errors.has('Credits.CreditCounts') }" style="display: initial;" />
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2" style="top: 10px;">
                                    Maximální Limit Kreditů
                                </div>
                                <div class="col-md-6 py-2 text-right">
                                    <input type="text" v-model="Credits.CreditVariant" :disabled="editMaxDisabled" v-on:input="validateForm('Credits')" v-validate="{required: true,numeric:true, min_value:0, max_value: 9999999}" name="CreditVariant" class="form-control form_control_set_width_2 text-right" :class="{ 'is-invalid': errors.has('Credits.CreditVariant') }" style="display: initial;" />
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2" style="top: 10px;">
                                    Cena tarifu v Kč
                                </div>
                                <div class="col-md-6 py-2 text-right">
                                    <input type="text" v-model="Credits.Price" v-on:input="validateForm('Credits')" v-validate="{required: true,numeric:true, min_value:0, max_value: 999999}" name="Price" class="form-control form_control_set_width_2 text-right" :class="{ 'is-invalid': errors.has('Credits.Price') }" style="display: initial;" />
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-2 py-2" style="top: 10px;">
                                    Poznámka
                                </div>
                                <div class="col-md-10 py-2 text-right">
                                    <input type="text" v-model="Credits.Note" v-on:input="validateForm('Credits')" v-validate="{required: false, max: 255}" name="Note" class="form-control py-2" :class="{ 'is-invalid': errors.has('Credits.Note') }" style="display: initial;" />
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-3 py-2" style="top: 10px;">
                                    Interní Poznámka
                                </div>
                                <div class="col-md-9 py-2 text-right">
                                    <textarea rows="3" v-model="Credits.InternalNote" v-on:input="validateForm('Credits')" v-validate="{required: false, max: 2048}" name="InternalNote" class="form-control py-2" :class="{ 'is-invalid': errors.has('Credits.InternalNote') }" style="display: initial;resize: none;" />
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item py-4">
                            <button class="btn btn-outline-secondary btn_new" :disabled="saveDisabled" v-on:click="Save()">Uložit</button>
                        </div>
                    </form>
                </div>
            </div>
            <p style="height:60px;"></p>
            </div>
        </div>
    </div>
</template>

<script>
    import VeeValidate from 'vee-validate';
	import Vue from 'vue';
	import SlimDialog from 'v-slim-dialog';
	import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';
    import Datepicker from 'vuejs-datepicker';
    import dpcs from 'vuejs-datepicker/dist/locale/translations/cs';

	import cs from "vee-validate/dist/locale/cs";
	import en from "vee-validate/dist/locale/en";

	Vue.use(SlimDialog);
	Vue.use(VueI18n);
	Vue.use(VueCookie);

	const locale = Vue.cookie.get('locale') || 'cs';
	const i18n = new VueI18n({
	  locale: locale
	});

   	Vue.use(VeeValidate, {
	  i18n,
	  dictionary: {
		cs,en
	  }
	});
	
    export default {
        components: {
            Datepicker
        },
        data() {
            return {
                dpcs: dpcs,
                authUser: Vue.cookie.get('logged') || false,
                Credits: {
                    a_box: "",
                    a_cha: "",
                    InvoicePeriod: "",
                    PaymentVersion: "",
                    Trial: false,
                    CreditVariant: 0,
                    CreditCounts: 0,
                    NextPayDate: "",
                    CreditNextPayDate: "",
                    Price: 0,
                    isAdmin: false,
                    topVariablesAllowed: false,
                    abTestingAllowed:false,
                    groupId: null,
                    Note: "",
                    InternalNote:""
                },
                appSettings: [],
                adminGroupId: null,
                adminAccount: false,
                userUid: "none",
                userEmail: null,
                saveDisabled: false,
                editMaxDisabled: true 
            };
        },
        methods: {
            validateForm(scope) {
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        this.saveDisabled = false;
                       
                    } else {
                        this.saveDisabled = true;
                    }
                });
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            Save() {
                var that = this;
                if (that.userUid != "none") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/update_user",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({
                            session: Vue.cookie.get('session'),
                            a_box: (that.Credits.a_box) ? that.Credits.a_box : "",
                            a_cha: (that.Credits.a_cha) ? that.Credits.a_cha : "",
                            InvoicePeriod: (that.Credits.InvoicePeriod) ? that.Credits.InvoicePeriod : "",
                            PaymentVersion: (that.Credits.PaymentVersion) ? that.Credits.PaymentVersion : "",
                            Trial: (that.Credits.Trial) ? that.Credits.Trial : false,
                            CreditVariant: (that.Credits.CreditVariant) ? that.Credits.CreditVariant : 0,
                            CreditCounts: (that.Credits.CreditCounts) ? that.Credits.CreditCounts : 0,
                            NextPayDate: (that.Credits.NextPayDate) ? that.Credits.NextPayDate : "",
                            CreditNextPayDate: (that.Credits.CreditNextPayDate) ? that.Credits.CreditNextPayDate : "",
                            Price: (that.Credits.Price) ? that.Credits.Price : 0,
                            uuid: that.userUid,
                            groupId: (that.Credits.groupId) ? that.Credits.groupId : 0,
                            isAdmin: (that.Credits.isAdmin) ? that.Credits.isAdmin : false,
                            topVariablesAllowed: (that.Credits.topVariablesAllowed) ? that.Credits.topVariablesAllowed : false,
                            abTestingAllowed: (that.Credits.abTestingAllowed) ? that.Credits.abTestingAllowed : false,
                            note: (that.Credits.Note) ? that.Credits.Note : "",
                            internalNote: (that.Credits.InternalNote) ? that.Credits.InternalNote : ""
                        })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.showAlert("Uloženo");
                        } else {
                            that.showAlert(data.code);
                        }
                    })
                }
            },
            SelectCreditCount() {
                this.validateForm('Credits');
                var that = this;
                this.appSettings.forEach(function (entry, index) {
                    if (entry.paymentVersion === that.Credits.PaymentVersion && entry.invoicePerriod === that.Credits.InvoicePeriod) {
                        that.Credits.CreditCounts = parseInt(entry.creditVariant);
                        that.Credits.Price = parseInt(entry.price);
                        that.Credits.CreditVariant = that.Credits.CreditCounts;
                    }
                });
                if (that.Credits.PaymentVersion == "Trial" || that.Credits.PaymentVersion == "Enterprise") { that.editMaxDisabled = false; } else that.editMaxDisabled = true;
            },
        },

        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/auth_status",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    if (data.isAdmin) {
                        that.adminGroupId = data.groupId;
                        that.adminAccount = true;
                    } else {
                        that.adminGroupId = null;
                        that.adminAccount = false;
                        window.location.pathname = '/';
                    }
                } else {
                    that.adminGroupId = null;
                    that.adminAccount = false;
                    window.location.pathname = '/';
                }
            });
        },

        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (that.userUid != "none") {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/user_credits",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (data) {
                    if (data.result === 1) {

                        //console.log(data);

                        that.Credits.a_box = data.a_box;
                        that.Credits.a_cha = data.a_cha;
                        that.Credits.InvoicePeriod = data.InvoicePeriod;
                        that.Credits.PaymentVersion = data.PaymentVersion;
                        that.Credits.Trial = data.Trial;
                        that.Credits.CreditVariant = data.CreditVariant;
                        that.Credits.CreditCounts = data.CreditCounts;
                        that.Credits.NextPayDate = data.NextPayDate;
                        that.Credits.CreditNextPayDate = data.CreditNextPayDate;
                        that.Credits.Price = data.Price;
                        that.Credits.isAdmin = data.isAdmin;
                        that.Credits.groupId = data.groupId;
                        that.Credits.topVariablesAllowed = data.topVariablesAllowed;
                        that.Credits.abTestingAllowed = data.abTestingAllowed;
                        that.Credits.Note = data.note;
                        that.Credits.InternalNote = data.internalNote;

                        that.editMaxDisabled = (data.PaymentVersion == "Trial" || data.PaymentVersion == "Enterprise") ? false : true;
                    }
                });

                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_appsettings",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session') })
                }).done(function (data) {
                    if (data.result === 1) {
                        that.appSettings = data.appsettings;
                    }
                });

            }
        }
    }
</script>

<style lang="scss" scoped type="text/css">
</style>