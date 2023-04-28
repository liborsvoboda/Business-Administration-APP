<template>
    <div id="app" :style="[background ? {'backgroundColor': '#fff'} : {'backgroundColor': '#efefef'}]">
        <div v-show="!loadingFinished && !thirdParty" class="loading" >Loading&#8230;</div>
        <router-view></router-view>
    </div>
</template>
<script>
    export default {
        name: 'app',
        data() {
            return {
                loadingFinished: false,
            }
        },
        computed: {
            background() {
                const path = this.$route.path.split('/')
                return path[path.length - 1].toLowerCase() === 'businessexternal' || path[path.length - 1].toLowerCase() === 'shoptet'
            },
            thirdParty() {
                const path = this.$route.path.split('/')
                return path[path.length - 1].toLowerCase() === 'businessexternal' || path[path.length - 1].toLowerCase() === 'shoptet'
            }
        },
        created() {
            document.onreadystatechange = () => {
                if (document.readyState == "complete") {
                    this.loadingFinished = true;
                }
            }
        }
    }
</script>

<style>

   
</style>