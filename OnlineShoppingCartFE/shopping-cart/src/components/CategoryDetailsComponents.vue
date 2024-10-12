<template>
    <HeaderComponents @search="handleSearch" />

    <div class="breadcrumb">
        <div class="container">
            <div class="breadcrumb-inner">
                <ul class="list-inline list-unstyled">
                    <li><a href="#">Home</a></li>
                    <li class='active'>Handbags</li>
                </ul>
            </div>
            <!-- /.breadcrumb-inner -->
        </div>
        <!-- /.container -->
    </div>
    <!-- /.breadcrumb -->
    <div class="body-content outer-top-xs">
        <div class='container'>
            <div class='row'>
                <!-- /.sidebar -->
                <div class='col-md-12'>
                    <!-- ========================================== SECTION – HERO ========================================= -->
                    <div class="clearfix filters-container m-t-10">
                        <div class="row">
                            <div class="col col-sm-6 col-md-2">
                                <div class="filter-tabs">
                                    <ul id="filter-tabs" class="nav nav-tabs nav-tab-box nav-tab-fa-icon">
                                        <li class="active"> <a data-toggle="tab" href="#grid-container"><i
                                                    class="icon fa fa-th-large"></i>Grid</a> </li>

                                    </ul>
                                </div>
                                <!-- /.filter-tabs -->
                            </div>
                            <!-- /.col -->
                            <div class="col col-sm-12 col-md-6">

                                <!-- /.col -->
                                <div class="col col-sm-3 col-md-6 no-padding">

                                    <!-- /.lbl-cnt -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.col -->
                            <div class="col col-sm-6 col-md-4 text-right">
                                <div class="pagination-container" style="display: flex; float: right;">
                                    <li class="prev"><a @click="previousPage"
                                            style="border: 1px solid; padding: 0 4px 0 4px;" href="#"><i
                                                class="fa fa-angle-left"></i></a></li>
                                    <ul class="list-inline list-unstyled" v-for="page in totalPages" :key="page">
                                        <li><a href="#" @click="changePage(page)">{{ page }}</a></li>
                                    </ul>
                                    <li class="next"><a @click="nextPage"
                                            style="border: 1px solid; padding: 0 4px 0 4px;" href="#"><i
                                                class="fa fa-angle-right"></i></a></li>
                                    <!-- /.list-inline -->
                                </div>
                                <!-- /.pagination-container -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <div class="search-result-container ">
                        <div id="myTabContent" class="tab-content category-list">
                            <div class="tab-pane active " id="grid-container">
                                <div class="category-product" v-if="paginatedData && paginatedData.length > 0">
                                    <div class="row" v-if="searchKeyword == ''">
                                        <div class="col-sm-6 col-md-4 wow fadeInUp" v-for="p in paginatedData"
                                            :key="p.id">
                                            <div class="products">
                                                <div class="product">
                                                    <div class="product-image">
                                                        <div class="image"> <router-link
                                                                :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }"><img
                                                                    :src="p.imageProduct" alt=""></router-link>
                                                        </div>
                                                        <!-- /.image -->

                                                        <div class="tag new"><span>new</span></div>
                                                    </div>
                                                    <!-- /.product-image -->

                                                    <div class="product-info text-left">
                                                        <h3 class="name"><router-link
                                                                :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }">{{
                                                                    p.productName }}</router-link>
                                                        </h3>
                                                        <div class="rating rateit-small"></div>
                                                        <div class="description"></div>
                                                        <div class="product-price"> <span class="price">{{
                                                            p.formattedPrice
                                                                }}</span>

                                                        </div>
                                                        <!-- /.product-price -->

                                                    </div>
                                                    <!-- /.product-info -->
                                                    <div class="cart clearfix animate-effect">
                                                        <div class="action">
                                                            <ul class="list-unstyled">
                                                                <li class="add-cart-button btn-group">
                                                                    <button class="btn btn-primary icon"
                                                                        data-toggle="dropdown" type="button"> <i
                                                                            class="fa fa-shopping-cart"></i> </button>
                                                                    <button class="btn btn-primary cart-btn"
                                                                        type="button">Add to cart</button>
                                                                </li>
                                                                <li class="lnk wishlist"> <a class="add-to-cart"
                                                                        href="detail.html" title="Wishlist"> <i
                                                                            class="icon fa fa-heart"></i> </a> </li>
                                                                <li class="lnk"> <a class="add-to-cart"
                                                                        href="detail.html" title="Compare"> <i
                                                                            class="fa fa-signal"></i> </a> </li>
                                                            </ul>
                                                        </div>
                                                        <!-- /.action -->
                                                    </div>
                                                    <!-- /.cart -->
                                                </div>
                                                <!-- /.product -->

                                            </div>
                                            <!-- /.products -->
                                        </div>
                                    </div>
                                    <div class="row" v-else>
                                        <div class="col-sm-6 col-md-4 wow fadeInUp" v-for="p in paginatedData"
                                            :key="p.id">
                                            <div class="products">
                                                <div class="product">
                                                    <div class="product-image">
                                                        <div class="image"> <router-link
                                                                :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }"><img
                                                                    :src="p.imageProduct" alt=""></router-link>
                                                        </div>
                                                        <!-- /.image -->

                                                        <div class="tag new"><span>new</span></div>
                                                    </div>
                                                    <!-- /.product-image -->

                                                    <div class="product-info text-left">
                                                        <h3 class="name"><router-link
                                                                :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }">{{
                                                                    p.productName }}</router-link>
                                                        </h3>
                                                        <div class="rating rateit-small"></div>
                                                        <div class="description"></div>
                                                        <div class="product-price"> <span class="price">{{ p.formattedPrice
                                                                }}</span>
                                                        </div>
                                                        <!-- /.product-price -->

                                                    </div>
                                                    <!-- /.product-info -->
                                                    <div class="cart clearfix animate-effect">
                                                        <div class="action">
                                                            <ul class="list-unstyled">
                                                                <li class="add-cart-button btn-group">
                                                                    <button class="btn btn-primary icon"
                                                                        data-toggle="dropdown" type="button"> <i
                                                                            class="fa fa-shopping-cart"></i> </button>
                                                                    <button class="btn btn-primary cart-btn"
                                                                        type="button">Add to cart</button>
                                                                </li>
                                                                <li class="lnk wishlist"> <a class="add-to-cart"
                                                                        href="detail.html" title="Wishlist"> <i
                                                                            class="icon fa fa-heart"></i> </a> </li>
                                                                <li class="lnk"> <a class="add-to-cart"
                                                                        href="detail.html" title="Compare"> <i
                                                                            class="fa fa-signal"></i> </a> </li>
                                                            </ul>
                                                        </div>
                                                        <!-- /.action -->
                                                    </div>
                                                    <!-- /.cart -->
                                                </div>
                                                <!-- /.product -->

                                            </div>
                                            <!-- /.products -->
                                        </div>
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <div v-else>
                                    <p class="text-center">Không có sản phẩm!</p>
                                </div>
                                <!-- /.category-product -->

                            </div>
                            <!-- /.tab-pane -->
                            <!-- /.tab-pane #list-container -->
                        </div>
                        <!-- /.tab-content -->
                        <!-- /.filters-container -->

                    </div>
                    <!-- /.search-result-container -->

                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- ============================================== BRANDS CAROUSEL ============================================== -->
            <div id="brands-carousel" class="logo-slider wow fadeInUp">
                <div class="logo-slider-inner">
                    <div id="brand-slider" class="owl-carousel brand-slider custom-carousel owl-theme">
                        <div class="item m-t-15"> <a href="#" class="image"> <img
                                    data-echo="assets/images/brands/brand1.png" src="assets\images\blank.gif" alt="">
                            </a> </div>
                        <!--/.item-->

                        <div class="item m-t-10"> <a href="#" class="image"> <img
                                    data-echo="assets/images/brands/brand2.png" src="assets\images\blank.gif" alt="">
                            </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand3.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand4.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand5.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand6.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand2.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand4.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand1.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->

                        <div class="item"> <a href="#" class="image"> <img data-echo="assets/images/brands/brand5.png"
                                    src="assets\images\blank.gif" alt=""> </a> </div>
                        <!--/.item-->
                    </div>
                    <!-- /.owl-carousel #logo-slider -->
                </div>
                <!-- /.logo-slider-inner -->

            </div>
            <!-- /.logo-slider -->
            <!-- ============================================== BRANDS CAROUSEL : END ============================================== -->
        </div>
        <!-- /.container -->

    </div>
    <!-- /.body-content -->
    <!-- ============================================================= FOOTER ============================================================= -->
    <FooterComponents />

</template>

<script>
import axios from 'axios';
import HeaderComponents from './HeaderComponents';
import FooterComponents from './FooterComponents';

export default {
    name: "HomePage",
    components: {
        HeaderComponents, FooterComponents
    },
    data() {
        return {
            products: [],
            searchKeyword: '',
            pageSize: 6,
            currentPage: 1,
            totalPages: 0,
            totalItems: 0
        }
    },
    computed: {
        filteredProductData() {
            if (this.searchKeyword) {
                return this.products.filter(product => product.productName.includes(this.searchKeyword));
            } else {
                return this.products;
            }
        },
        paginatedData() {
            const startIndex = (this.currentPage - 1) * this.pageSize;
            const endIndex = startIndex + this.pageSize;
            // return this.filteredProductData.slice(startIndex, endIndex);
            return this.filteredProductData.slice(startIndex, endIndex).map(product => ({
                ...product,
                formattedPrice: new Intl.NumberFormat('vi-VN', {
                    style: 'currency',
                    currency: 'VND'
                }).format(product.price)
            }));
        },
        totalPages() {
            return Math.ceil(this.filteredProductData.length / this.pageSize);
        }
    },
    methods: {
        loadProducts() {
            const categoryId = this.$route.params.categoryId;
            var url = process.env.VUE_APP_BASE_API_URL + `/Products/category/${categoryId}`;
            axios.get(url)
                .then(response => {
                    this.products = response.data;
                    this.totalItems = this.products.length;
                    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
                })
                .catch(error => {
                    console.error('Error loading products:', error);
                });
        },
        changePage(page) {
            this.currentPage = page;
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
            }
        },
        handleSearch(keyword) {
            this.searchKeyword = keyword;
            this.currentPage = 1; // Reset to the first page when a new search is performed
        }
    },
    mounted() {
        this.loadProducts();
    },
    watch: {
        '$route'(to, from) {
            if (to.params.categoryId !== from.params.categoryId) {
                this.loadProducts();
            }
        }
    }
}
</script>

<style scoped></style>