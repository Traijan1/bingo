<template>
    <div class="board">
        <span :key="field" v-for="field in props.board.fields" @click="click(field)" class="field">
            <BingoField :field="field" :key="rerender" />
        </span>
    </div>;
</template>

<script setup lang="ts">
    import { defineProps, ref, defineEmits } from 'vue';
    import { Board } from '@/models/board';
    import BingoField from "./BingoField.vue";
    import { Field } from '@/models/field';

    const props = defineProps<{ board: Board }>();
    const emits = defineEmits<{ (e: "update" ): void }>();

    const rerender = ref(0); // Look for a better solution to rerender BingoField
    const columnSize = Math.round(Math.sqrt(props.board.fields.length));

    function click(field: Field) {
        console.log("click");
        field.isDone = !field.isDone;
        rerender.value++;

        emits("update");
    }
</script>

<style lang="scss" scoped>
    $border-width: 1.5px;
    $size: 120px;
    
    .board {
        display: grid;
        grid-template-columns: repeat(v-bind(columnSize), $size);
        grid-template-rows: repeat(v-bind(columnSize), $size);
    }

    .field {
        position: relative;
        padding: 10px;
        border: $border-width solid #494848;
        background-color: #121212;
        color: white;
    }
</style>