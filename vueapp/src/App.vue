<template>
    <div class="container">
        <h3 class="main-title">DM365 News</h3>
        <input class="searchInput" placeholder="Search..."
               v-model="searchQuery" />
        <news-list :allNews="searchedNews" v-if="!isNewsLoading" />
        <div v-else>Loading...</div>
    </div>
</template>

<script>
    import axios from 'axios';
    import NewsList from "@/components/NewsList";

    export default {
        components: {
            NewsList
        },
        data() {
            return {
                allNews: [],
                isNewsLoading: false,
                searchQuery: ''
            }
        },
        methods: {
            async fetchNews() {
                try {
                    this.isNewsLoading = true;
                    const response = await axios.get('https://localhost:7237/News/GetAll');
                    this.allNews = response.data;
                }
                catch (e) {
                    alert("Îøèáêà")
                } finally {
                    this.isNewsLoading = false;
                }
            }
        },
        mounted() {
            this.fetchNews();
        },
        computed: {
            searchedNews() {
                return this.allNews.filter(news => news.title.toLowerCase().includes(this.searchQuery.toLowerCase()));
            }
        }
    }
</script>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');

    .container {
        text-align: center;
    }

    .main-title {
        font-family: 'Roboto';
        font-size: 26px;
        text-align: center;
        color: teal;
    }

    .searchInput {
        color: teal;
        border: 1px solid teal;
        background: none;
        border-radius: 5px;
        margin: 0px 15px 30px;
        width: 70%;
        align-self: center;
        padding: 10px;
    }
</style>
