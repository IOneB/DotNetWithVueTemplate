<template>
  <div>
    {{ data }}
  </div>
</template>

<script>
export default {
  data() {
    return {
      data: [],
    };
  },
  async created() {
    const resp = await fetch("http://localhost:5000/Work");
    this.data = await resp.json();
  },
};
</script>
