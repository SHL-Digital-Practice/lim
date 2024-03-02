<template>
  <div>
    catalogue
    {{ species }}
  </div>
</template>

<script setup lang="ts">
import type { Database } from "../types/supabase";

const client = useSupabaseClient<Database>();

const { data: species, pending } = useAsyncData("species", async () => {
  const { data, error } = await client.from("species").select().limit(50);

  return data;
});
</script>

<style scoped></style>
