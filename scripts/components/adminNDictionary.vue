<template>
    <div class="pb-5" v-show="authUser=='true' && adminAccount">
        <div v-show="!loadingFinished" class="loading">Loading&#8230;</div>
        <div class="row justify-content-center pb-5">
            <div class="col-lg-11 col-xl-9">
                <h2 class="py-3 pt-5 pb-4 text-center">Slovník notifikací</h2>
                <div class="list-group mt-2">
                    <h2 class="list-group-item group_item_blue bold py-3">
                        Obsah slovníku
                    </h2>
                    <div class="list-group-item" style="padding: 1.25rem 1.25rem">
                        <v-table is-horizontal-resize
                                 column-width-drag
                                 even-bg-color="#f2f2f2"
                                 row-hover-color="#edf6e2"
                                 row-click-color="#edf7ff"
                                 sort-always
                                 style="width:100%;"
                                 :columns="columns"
                                 :table-data="rows"
                                 :cell-edit-done="cellEditDone"></v-table>
                    </div>
                </div>
            </div>
            <p style="height:60px;"></p>
        </div>

        <div class="container-bottom-buttons new_campaign_container_but">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 d-flex justify-content-between p-0">
                        <div class="justify-content-start">
                            <button class="btn btn-outline-secondary btn_new_campaign" v-on:click="back()">
                                <i class="fas fa-chevron-circle-left"></i>&nbsp;&nbsp;&nbsp; Zpět
                            </button>
                        </div>
                    </div>
                </div>
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
    import NProgress from 'nprogress';

    import 'vue-easytable/libs/themes-base/index.css'
    import { VTable, VPagination } from 'vue-easytable'
    Vue.component(VTable.name, VTable)
    Vue.component(VPagination.name, VPagination)

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

                columns: [],
                rows: [],
                adminAccount: false,
                userUid: "none",
                userEmail: null
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
            back() {
                window.location.pathname = '/AdminClientList';
            },

            cellEditDone(newValue, oldValue, rowIndex, rowData, field) {
                var that = this;
                if (newValue != oldValue) {

                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/updateNDictionary",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({
                            session: Vue.cookie.get('session'),
                            id: rowData.id,
                            column: field,
                            value: newValue
                        })
                    }).done(function (data) {
                        //console.log("edit", newValue, oldValue, rowIndex, rowData, field)
                        that.rows[rowIndex][field] = newValue;
                    });
                }
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            loadDictionary() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/getNDictionary",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({
                        session: Vue.cookie.get('session')
                    })
                }).done(function (data) {
                    that.columns = [{ title: 'Id', field: 'id', width: 30, isResize: true }
                        , { title: 'SystemName', field: 'systemName', width: 150, isResize: true }
                        , { title: 'Česky', field: 'cs', isEdit: true, width: 150, isResize: true }
                        , { title: 'Slovensky', field: 'sk', isEdit: true, width: 150, isResize: true }
                        , { title: 'Anglicky', field: 'en', isEdit: true, width: 150, isResize: true }
                        , { title: 'Použití', field: 'using', width: 100, isResize: true }
                    ];
                    that.rows = []; let saveData = false;
                    data.nDictionary.forEach(function (dictionary, index, arr) {
                        that.rows.push({
                            id: dictionary.id,
                            systemName: dictionary.systemName,
                            cs: dictionary.cs,
                            sk: dictionary.sk,
                            en: dictionary.en,
                            using: dictionary.using
                        });
                    });
                });
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
            this.loadDictionary();
            this.loadingFinished = true;
        }
    } 
</script>

<style lang="scss" scoped type="text/css">
</style>