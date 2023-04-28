<template>
	<a href="/Login" class="btn btn-primary btn_nav_other" v-if="!authUser" >
		<span class="fas fa-sign-out-alt"></span> Přihlásit
	</a>
	<button class="btn btn-primary btn_nav_other" v-else-if="authUser != 'empty'" @click="signOut" >
		<span class="fas fa-sign-out-alt"></span> Odhlásit
	</button>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);
	export default {
	data() {
	    return {
	        authUser: "empty" //eliminate async switch
	    }
	},

	methods: {
        signOut() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/logout",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    Vue.cookie.set('topVariables', null, 1);
                    Vue.cookie.set('session', null, 1);
                    Vue.cookie.set('logged', false, 1);
                    window.location.pathname = '/Login'; 
                } else {
                    Vue.cookie.set('topVariables', null, 1);
                    Vue.cookie.set('session', null, 1);
                    Vue.cookie.set('logged', false, 1);
                    window.location.pathname = '/Login'; 
                }
            });
	    },

	},

	
        created() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/auth_status",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    that.authUser = true;
                } else {
                    Vue.cookie.set('topVariables', null, 1);
                    Vue.cookie.set('session', null, 1);
                    Vue.cookie.set('logged', false, 1);
                    that.authUser = false;
                }
            });
    	}
	}
</script>