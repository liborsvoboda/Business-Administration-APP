<template>
    <div class="meet_team_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-4 pt-3">
                <button ref="closeBtn" type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12 text-center pt-2 pb-2">
                <h1 class="panel_right_h2">Poznejte náš tým</h1>
            </div>
            <div class="col-md-12 py-2">
                <img src="/images/our_team.jpg" alt="Náš tým" class="img-fluid" />
            </div>

            <div class="col-md-6 py-2 text-center">
                <h5 class="">Petr Panzner</h5>
                <h7 class="">Jednatel a mozek společnosti</h7>
            </div>
            <div class="col-md-6 py-2 text-center">
                <h5 class="">Kateřina Svobodová</h5>
                <h7 class="">Marketing a srdce společnosti</h7>
            </div>

            <div class="col-md-12 pt-4 text-center pb-5">
                <button class="btn btn-outline-secondary btn_new" @click="update">Dokončit krok</button>
            </div>
        </div>
    </div>
</template>


<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';
	import SlimDialog from 'v-slim-dialog';

    Vue.use(SlimDialog);
    Vue.use(VueCookie);

    export default {
        data() {
            return {
                StepTeam: {
                    Finished: false
                },
            }
        },
        methods: {
            update() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/update_team",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'),Finished: true })
                }).done(function (updateTeam) {
                    if (updateTeam.result == 1) {
                        $.ajax({
                            type: "POST",
                            url: "https://appi.app.cz:444/get_team",
                            dataType: "json",
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify({ session: Vue.cookie.get('session') })
                        }).done(function (dataTeam) {
                            that.StepTeam.Finished = dataTeam.Finished;
                            that.$emit("changesFinished", that.StepTeam.Finished);
                            that.$refs.closeBtn.click();/*this.showAlert("Saved");*/
                        })
                    }
                    
                })
            },
			showAlert(val) {
			    const options = {title: 'Info', size: 'sm'}
			    this.$dialogs.alert(val, options)
					.then(res => {
				});
			},
        },
        created() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_team",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (dataTeam) {
                that.StepTeam.Finished = dataTeam.Finished;
                that.$emit("changesFinished", that.StepTeam.Finished);
            })
        }
    }
</script>