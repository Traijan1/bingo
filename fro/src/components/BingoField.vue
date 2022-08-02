<template>
    {{ field.title }}
    <img v-if="field.isDone" src="@/assets/check.svg" />
</template>

<script setup lang="ts">
    import { Field } from '@/models/field';
    import { defineProps } from 'vue';

    defineProps<{ field: Field }>();
</script>

<style lang="scss" scoped>
    img {
        width: 80px;
        position: absolute;
        top: 15px;
        left: 20px;
    }
</style>