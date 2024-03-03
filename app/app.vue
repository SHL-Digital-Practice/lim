<template>
  <div class="bg-neutral-100">
    <BaseNavbar />
    <NuxtPage />
  </div>
</template>

<script setup lang="ts">
import { initFlowbite } from "flowbite";

onMounted(() => {
  initFlowbite();
});
</script>
