<template>
    <BingoBoard v-if="board != undefined" :board="board" @update="update" />
</template>

<script setup lang="ts">
    import { defineProps, onBeforeMount, ref, Ref } from 'vue';
    import { Board } from '../models/board';
    import BingoBoard from "../components/BingoBoard.vue";
    import BingoService from "@/services/BingoService";
    import { BingoHub } from "@/services/BingoHub";

    const props = defineProps<{
        id: string
    }>();

    let board: Ref<Board|undefined> = ref(undefined);

    async function create(): Promise<void> {
        board.value = await BingoService.getBoard(props.id);

        BingoHub.on("RecvBoard", b => {
            board.value = b;
            console.log(board);
        });

        await BingoHub.start();
        BingoHub.send("RecvClient", props.id);
    }

    async function update() {
        await BingoHub.invoke("SendBoard", board.value, props.id);
    }

    onBeforeMount(async () => await create());
    // TODO: atm does not update while chaning id => have to press f5 to refresh page
</script>

<style lang="scss" scoped>

</style>