<template>
	<div>
		<div class="label">{{ $t('language') }}
		</div>
		<img src="/images/flags/cs_flag.png" v-on:click="setLanguage('cs')" v-bind:alt="$t('czech')" v-bind:title="$t('czech')" class="flag_img" :class="{active: locale === 'cs'}" v-model="locale" />
		<img src="/images/flags/en_flag.png" v-on:click="setLanguage('en')" v-bind:alt="$t('english')" v-bind:title="$t('english')" class="flag_img" :class="{active: locale === 'en'}" v-model="locale" />
		<!--<select v-model="locale" style="nav-item pb-md-3">
			<option value="cs">{{ $t('czech') }}</option>
			<option value="en">{{ $t('english') }}</option>
		</select>-->
	</div>
</template>

<script>
	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
	Vue.use(VueCookie);
	
	Vue.config.lang = Vue.cookie.get('locale') || 'cs';

	export default {
		components: {
		},
		data () {
			return {
				locale: Vue.config.lang
			}
		},
		methods: {
			setLanguage(val){
				this.$i18n.locale = val;
				Vue.cookie.set('locale',val,1);	
				this.locale = val;
			},
		},
		watch: {
			locale (val) {
				this.$i18n.locale = val;
				this.locale = val;
				Vue.cookie.set('locale',val,1);
			}
		}
	}
</script>
