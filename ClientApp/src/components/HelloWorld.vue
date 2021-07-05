<template>
  <div v-if="loaded">
    <div class="card" v-if="works.length">
        <div v-for="work in works" :key="work.Id">
          <span>{{ work.Name }}</span>
        </div>
    </div>
    <h1 v-else>Oops, there is nothing...</h1>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "HelloWorld",
  data() {
    return {
      loaded: false,
      works: [],
    };
  },
  mounted() {
    axios
      .get("/Work")
      .then((response) => {
        this.works = response.data;
      })
      .catch((error) => {
        alert("OMG! Something goes wrong!");
        console.error(error);
      })
      .finally(() => (this.loaded = true));
  },
};
</script>

<style scoped>
.card {
  width: 80%;
  background-color: white;
  padding: 1rem 5rem;
  border-radius: 1.2rem;
  margin-left: auto;
  margin-right: auto;
}
</style>
