<template>
  <div
    class="w-36 h-6 px-2.5 py-0.5 bg-emerald-100 rounded-xl justify-start items-center inline-flex"
  >
    <p class="text-emerald-800 text-sm font-medium leading-tight">
      {{ label }}
    </p>
  </div>
</template>

<script setup lang="ts">
const props = defineProps<{
  label: string;
}>();
</script>

<style scoped></style>
