<template>
    <div class="container" v-show="authUser=='true' && adminAccount">
        <div v-show="!loadingFinished" class="loading">Loading&#8230;</div>
        <div class="row justify-content-center">
            <div class="col-lg-11 col-xl-9">
                <h2 class="py-3 pt-5 pb-4 text-center">DB Nástroje</h2>

                <div class="list-group mt-2">
                    <form @submit.prevent="validateForm('ScriptForm')" data-vv-scope="ScriptForm">
                        <h2 class="list-group-item group_item_blue bold py-3">
                            SPUŠTĚNÍ SCRIPTŮ NAD KLIENTEM
                        </h2>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-12 py-2">
                                    <input type="text" :readonly="(1== 1) ? true : false" placeholder="Id Klienta" v-model="userUid" name="userUid" v-validate="{ required: true}" class="form-control py-2" :class="{ 'is-invalid': errors.has('userUid') }" />
                                    <span v-if="errors.has('userUid')" class="invalid-feedback">{{ errors.first('userUid') }}</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 py-2">
                                    <div class="text-center">Vyberte Script:</div>
                                    <select v-model="scriptName" v-on:change="validateForm('ScriptForm')" style="max-width: 100%;" name="scriptName" v-validate="{required: true}" class="form-control" :class="{ 'is-invalid': errors.has('scriptName') }">
                                        <option disabled="" value="none">Vyberte</option>
                                        <option v-for="script in scripts" v-bind:value="script" @>{{ script }}</option>
                                    </select>
                                    <span v-if="errors.has('scriptName')" class="invalid-feedback">{{ errors.first('scriptName') }}</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item">
                            <div class="d-flex flex-row justify-content-between align-items-center pt-2">
                                <div style="padding-left: 20px;">Detailní výpis</div>
                                <div class="noselect">
                                    <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                                    <button type="button" class="btn btn-toggle" :class="{active: detailInfo}" v-on:click="detailInfo = !detailInfo" data-toggle="button" aria-pressed="false" autocomplete="off">
                                        <div class="handle"></div>
                                    </button>
                                    &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item py-4">
                            <button class="btn btn-outline-secondary btn_new" :disabled="runDisabled" v-on:click="runScript()">Spustit Script</button>
                        </div>

                        <div class="list-group-item">
                            <div class="row p-4">
                                <textarea v-model="resultArea" :readonly="(1== 1) ? true : false" placeholder="výsledky" class="form-control" rows="5" style="resize:none;"></textarea>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <p style="height:60px;"></p>
        </div>
    </div>
</template>

<script>
    import VeeValidate from 'vee-validate';
	import Vue from 'vue';
	import SlimDialog from 'v-slim-dialog';
	import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';
    import NProgress from 'nprogress';

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
        data() {
            return {
                authUser: Vue.cookie.get('logged') || false,
                loadingFinished: false,
                visitorIds: [],
                detailInfo: false,
                resultArea: "",
                scriptName: "none",
                scripts: ['Smazat Heureka', 'Smazat Návštěvy', 'Smazat Formuláře', 'Smazat celý účet'],

                adminAccount: false,
                adminAccess: false,
                userUid: "none",
                userEmail: null,
                runDisabled: true
            };
        },
        mounted() {
            document.onreadystatechange = () => {
                if (document.readyState == "complete") {
                    this.loadingFinished = true;
                }
            }
        },
        methods: {
            validateForm(scope) {
                var that = this;
                this.resultArea = "";
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        this.runDisabled = false;
                    } else {
                        this.runDisabled = true;
                    }
                });
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            runScript() {
                this.loadingFinished = false;
                NProgress.start();
                this.resultArea = "";
                this.visitorIds = [];
                var that = this;

                if (this.scriptName === "Smazat Heureka" && that.userUid != "none") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/delete",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid, what: "heureka" })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.resultArea += "Smazána Heureka\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        } else {
                            that.resultArea += "error" + data.message + "\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        }
                    });
 
                } 


                if (this.scriptName === "Smazat Návštěvy") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/delete",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid, what: "visits" })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.resultArea += "Smazáni Návštěvníci\r\n\r\n";
                            that.resultArea += "Smazány Návštěvy\r\n\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        } else {
                            that.resultArea += "error" + data.message + "\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        }
                    });
                }


                if (this.scriptName === "Smazat Formuláře") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/delete",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid, what: "forms" })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.resultArea += "Smazány Formuláře\r\n\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        } else {
                            that.resultArea += "error" + data.message + "\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        }
                    });
                }


                if (this.scriptName === "Smazat celý účet") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/delete",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid, what: "account" })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.resultArea += "Smazán Celý Účet\r\n\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        } else {
                            that.resultArea += "error" + data.message + "\r\n";
                            NProgress.done();
                            that.loadingFinished = true;
                        }
                    });
                }
                that.scriptName = "";
                that.runDisabled = true;
            }
          
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
                        that.adminAccount = true;
                        that.userUid = that.$store.state.AdminModule.adminUserKey;
                        that.userEmail = that.$store.state.AdminModule.adminUserEmail;
                    } else {
                        that.adminAccount = false;
                        window.location.pathname = '/';
                    }
                } else {
                    that.adminAccount = false;
                    window.location.pathname = '/';
                }
            });
        },

        created() {
           
            this.loadingFinished = true;
        }
    } 
</script>

<style lang="scss" scoped type="text/css">
</style>