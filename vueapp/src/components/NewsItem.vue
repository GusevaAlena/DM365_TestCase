<template>
    <div class="newsList-container">
        <div class="col-1-3">
            <img :src="news.imagePath" alt="newsImage" />
        </div>
        <div class="col-2-3">
            <p class="news-info">
                <span class="news-date">{{news.date}}</span>
            </p>
            <p class="news-title">
                <a class="newsLinkTitle" :href="news.reference">{{news.title}}</a>
            </p>
            <p class="news-notice">{{news.description}}</p>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            news: {
                type: Object,
                required: true
            }
        }
    }
</script>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');

    .newsList-container div {
        float: left;
        margin-bottom: 15px;
        height: 250px;
    }

    .col-1-3 {
        width: 33%
    }

        .col-1-3 img {
            width: 90%;
        }

    .col-2-3 {
        text-align: left;
        width: 67%;
    }

    .newsLinkTitle, .news-date {
        font-family: 'Roboto';
        font-size: 24px;
        color: inherit;
        text-decoration: none;
    }

    .news-date {
        color: darkred;
    }

    .newsLinkTitle:hover {
        color: darkred;
    }

    .news-notice {
        font-size: 18px;
    }
</style>