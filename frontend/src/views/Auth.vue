<template>
  <h1>Auth</h1>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class Auth extends Vue {
  async created() {
    const hashParams = this.parseHash(this.$route.hash.substr(1));
    if (hashParams.id_token) {
      localStorage.setItem("id_token", hashParams.id_token);
    } else {
      localStorage.removeItem("id_token");
    }

    if (hashParams.access_token) {
      localStorage.setItem("access_token", hashParams.access_token);
    } else {
      localStorage.removeItem("access_token");
    }

    if (hashParams.error) {
      console.error(hashParams.error);
      console.error(hashParams.error_description);
    } else {
      this.$store.dispatch("getUser");
      this.$router.push("/");
    }
  }

  parseHash(hash: string): any {
    const params: any = {};
    hash.split("&").forEach((item: any) => {
      const parts = item.split("=");
      params[parts[0]] = parts[1];
    });

    return params;
  }
}
</script>
