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
    const resp = await fetch("/api/Work");
    this.data = await resp.json();
  },
};
</script>
