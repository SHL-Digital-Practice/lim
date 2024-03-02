<template>
  <NuxtPage class="bg-neutral-100" />
</template>

<script setup lang="ts">
import { initFlowbite } from "flowbite";

onMounted(() => {
  initFlowbite();
});
</script>
