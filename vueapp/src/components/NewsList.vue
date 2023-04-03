<template>
    <div class="row">
        <news-item v-for="news in allNews" :key="news.id" :news="news" />
    </div>
</template>

<script>
    import NewsItem from "@/components/NewsItem";

    export default {
        components: {
            NewsItem
        },
        props: {
            allNews: {
                type: Array,
                required: true
            }
        }
    }
</script>

<style>
</style>