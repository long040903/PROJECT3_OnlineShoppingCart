<template>
    <HeaderComponents @search="handleSearch" />

    <!-- ============================================== HEADER : END ============================================== -->
    <div class="body-content outer-top-xs" id="top-banner-and-menu">
        <div class="container">
            <div class="row">
                <!-- ============================================== SIDEBAR ============================================== -->
                <div class="col-xs-12 col-sm-12 col-md-3 sidebar">

                    <!-- ================================== TOP NAVIGATION ================================== -->
                    <div class="side-menu animate-dropdown outer-bottom-xs">
                        <div class="head"><i class="icon fa fa-align-justify fa-fw"></i> Categories</div>
                        <nav class="yamm megamenu-horizontal">
                            <ul class="nav" v-for="c in categoryData" :key="c.id">
                                <li class="dropdown menu-item">
                                    <router-link :to="{ name: 'CategoryDetailsPageView', params: { categoryId: c.id } }"
                                        class="dropdown-toggle" data-toggle="dropdown"
                                        style="border-bottom: 1px solid #ddd;">
                                        <i class="icon fa fa-shopping-bag" aria-hidden="true"></i>
                                        {{ c.categoryName }}
                                    </router-link>
                                </li>

                            </ul>
                        </nav>
                    </div>

                    <div class="home-banner"> <img style="width: 262px; height: auto;"
                            src="assets\images\banners\home-banner3.jpg" alt="Image"> </div>
                    <div class="home-banner"> <img style="width: 262px; height: auto;"
                            src="assets\images\banners\home-banner4.jpg" alt="Image"> </div>

                </div>
                <!-- ============================================== SIDEBAR : END ============================================== -->

                <!-- ============================================== CONTENT ============================================== -->
                <div class="col-xs-12 col-sm-12 col-md-9 homebanner-holder">
                    <!-- ========================================== SECTION – HERO ========================================= -->

                    <div id="hero">
                        <div id="owl-main" class="owl-carousel owl-inner-nav owl-ui-sm">
                            <div class="item" style="background-image: url(assets/images/sliders/slide3.jpg);">
                                <div class="container-fluid">
                                    <div class="caption bg-color vertical-center text-left">
                                        <div class="slider-header fadeInDown-1">Top Quà Lưu Niệm</div>
                                        <div class="big-text fadeInDown-1"> Arts Shop </div>
                                        <div class="excerpt fadeInDown-2 hidden-xs"> <span>Chào mừng bạn đến với Art
                                                Shop, nơi đem đến cho bạn những lựa chọn thú vị.</span> </div>
                                        <div class="button-holder fadeInDown-3"> <a href="index.php?page=single-product"
                                                class="btn-lg btn btn-uppercase btn-primary shop-now-button">Shop
                                                Now</a> </div>
                                    </div>
                                    <!-- /.caption -->
                                </div>
                                <!-- /.container-fluid -->
                            </div>
                            <!-- /.item -->

                            <div class="item" style="background-image: url(assets/images/sliders/slide2.jpg);">
                                <div class="container-fluid">
                                    <div class="caption bg-color vertical-center text-left">
                                        <div class="slider-header fadeInDown-1">Top Quà Lưu Niệm</div>
                                        <div class="big-text fadeInDown-1"> Arts <span class="highlight">Shop</span>
                                        </div>
                                        <div class="excerpt fadeInDown-2 hidden-xs"> <span>Chào mừng bạn đến với Art
                                                Shop, nơi đem đến cho bạn những lựa chọn thú vị.</span> </div>
                                        <div class="button-holder fadeInDown-3"> <a href="index.php?page=single-product"
                                                class="btn-lg btn btn-uppercase btn-primary shop-now-button">Shop
                                                Now</a> </div>
                                    </div>
                                    <!-- /.caption -->
                                </div>
                                <!-- /.container-fluid -->
                            </div>
                            <!-- /.item -->

                        </div>
                        <!-- /.owl-carousel -->
                    </div>

                    <!-- ========================================= SECTION – HERO : END ========================================= -->

                    <!-- ============================================== INFO BOXES ============================================== -->
                    <div class="info-boxes wow fadeInUp">
                        <div class="info-boxes-inner">
                            <div class="row">
                                <div class="col-md-6 col-sm-4 col-lg-4">
                                    <div class="info-box">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <h4 class="info-box-heading green">money back</h4>
                                            </div>
                                        </div>
                                        <h6 class="text">30 Days Money Back Guarantee</h6>
                                    </div>
                                </div>
                                <!-- .col -->

                                <div class="hidden-md col-sm-4 col-lg-4">
                                    <div class="info-box">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <h4 class="info-box-heading green">free shipping</h4>
                                            </div>
                                        </div>
                                        <h6 class="text">Shipping on orders over $99</h6>
                                    </div>
                                </div>
                                <!-- .col -->

                                <div class="col-md-6 col-sm-4 col-lg-4">
                                    <div class="info-box">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <h4 class="info-box-heading green">Special Sale</h4>
                                            </div>
                                        </div>
                                        <h6 class="text">Extra $5 off on all items </h6>
                                    </div>
                                </div>
                                <!-- .col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.info-boxes-inner -->

                    </div>
                    <!-- /.info-boxes -->
                    <!-- ============================================== INFO BOXES : END ============================================== -->
                    <!-- ============================================== SCROLL TABS ============================================== -->
                    <div id="product-tabs-slider" class="scroll-tabs outer-top-vs wow fadeInUp">
                        <div class="more-info-tab clearfix ">
                            <h3 class="new-product-title pull-left">All Products</h3>
                            <ul class="nav nav-tabs nav-tab-line pull-right" id="new-products-1">
                                <div class="pagination-container" style="display: flex;">
                                    <li class="prev"><a @click="previousPage" style="border: 1px solid;" href="#"><i
                                                class="fa fa-angle-left"></i></a></li>
                                    <ul class="list-inline list-unstyled" v-for="page in totalPages" :key="page">
                                        <li><a href="#" @click="changePage(page)">{{ page }}</a></li>
                                    </ul>
                                    <li class="next"><a @click="nextPage" style="border: 1px solid;" href="#"><i
                                                class="fa fa-angle-right"></i></a></li>
                                    <!-- /.list-inline -->
                                </div>
                            </ul>
                            <!-- /.nav-tabs -->
                        </div>
                        <div class="tab-content outer-top-xs">
                            <div v-if="searchKeyword == '' || !searchKeyword">
                                <div class="row">
                                    <div class="col-md-3" v-for="p in paginatedData" :key="p.id">
                                        <div class="products">
                                            <div class="product">
                                                <div class="product-image">
                                                    <div class="image">
                                                        <router-link
                                                            :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }">
                                                            <img :src="p.imageProduct" alt="">
                                                        </router-link>
                                                    </div>
                                                </div>
                                                <div class="product-info text-left">
                                                    <h3 class="name">
                                                        <router-link
                                                            :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }">
                                                            {{ p.productName }}
                                                        </router-link>
                                                    </h3>
                                                    <div class="rating rateit-small"></div>
                                                    <div class="description"></div>
                                                    <div class="product-price">
                                                        <span class="price">{{ p.formattedPrice }}</span>
                                                    </div>
                                                </div>
                                                <div class="cart clearfix animate-effect">
                                                    <div class="action">
                                                        <ul class="list-unstyled">
                                                            <li class="add-cart-button btn-group">
                                                                <button data-toggle="tooltip"
                                                                    class="btn btn-primary icon" type="button"
                                                                    title="Add Cart">
                                                                    <i class="fa fa-shopping-cart"></i>
                                                                </button>
                                                            </li>
                                                            <li class="lnk wishlist">
                                                                <a data-toggle="tooltip" class="add-to-cart"
                                                                    href="detail.html" title="Wishlist">
                                                                    <i class="icon fa fa-heart"></i>
                                                                </a>
                                                            </li>
                                                            <li class="lnk">
                                                                <a data-toggle="tooltip" class="add-to-cart"
                                                                    href="detail.html" title="Compare">
                                                                    <i class="fa fa-signal" aria-hidden="true"></i>
                                                                </a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div v-else>
                                <div v-if="paginatedData.length > 0">
                                    <div class="row">
                                        <div class="col-md-3" v-for="p in paginatedData" :key="p.id">
                                            <div class="products">
                                                <div class="product">
                                                    <div class="product-image">
                                                        <div class="image">
                                                            <router-link
                                                                :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }">
                                                                <img :src="p.imageProduct" alt="">
                                                            </router-link>
                                                        </div>
                                                    </div>
                                                    <div class="product-info text-left">
                                                        <h3 class="name">
                                                            <router-link
                                                                :to="{ name: 'ProductDetailsPageView', params: { id: p.id } }">
                                                                {{ p.productName }}
                                                            </router-link>
                                                        </h3>
                                                        <div class="rating rateit-small"></div>
                                                        <div class="description"></div>
                                                        <div class="product-price">
                                                            <span class="price">{{ p.formattedPrice }}</span>
                                                        </div>
                                                    </div>
                                                    <div class="cart clearfix animate-effect">
                                                        <div class="action">
                                                            <ul class="list-unstyled">
                                                                <li class="add-cart-button btn-group">
                                                                    <button data-toggle="tooltip"
                                                                        class="btn btn-primary icon" type="button"
                                                                        title="Add Cart">
                                                                        <i class="fa fa-shopping-cart"></i>
                                                                    </button>
                                                                </li>
                                                                <li class="lnk wishlist">
                                                                    <a data-toggle="tooltip" class="add-to-cart"
                                                                        href="detail.html" title="Wishlist">
                                                                        <i class="icon fa fa-heart"></i>
                                                                    </a>
                                                                </li>
                                                                <li class="lnk">
                                                                    <a data-toggle="tooltip" class="add-to-cart"
                                                                        href="detail.html" title="Compare">
                                                                        <i class="fa fa-signal" aria-hidden="true"></i>
                                                                    </a>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div v-else>
                                    <div class="no-results">
                                        <h3 style="text-align: center;">Không có kết quả tìm kiếm phù hợp</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane in active" id="all">
                                <div class="product-slider">
                                    <div class="owl-carousel home-owl-carousel custom-carousel owl-theme" data-item="4">
                                        <div class="item item-carousel">
                                            <!-- Additional content for carousel -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- /.tab-content -->
                    </div>
                    <!-- /.scroll-tabs -->
                    <!-- ============================================== SCROLL TABS : END ============================================== -->
                </div>
                <!-- /.homebanner-holder -->
                <!-- ============================================== CONTENT : END ============================================== -->
            </div>
        </div>
        <!-- /.container -->
    </div>
    <!-- /#top-banner-and-menu -->

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
            productData: [],
            searchKeyword: '',
            pageSize: 8,
            currentPage: 1,
            totalPages: 0,
            totalItems: 0,
            currentProduct: {
                productName: "",
                imageProduct: null,
                price: "",
                description: "",
                barCode: "",
                categoryId: ""
            },
            categoryData: []
        }
    },
    computed: {
        filteredProductData() {
            if (this.searchKeyword) {
                return this.productData.filter(product => product.productName.includes(this.searchKeyword));
            } else {
                return this.productData;
            }
        },
        paginatedData() {
            const startIndex = (this.currentPage - 1) * this.pageSize;
            const endIndex = startIndex + this.pageSize;
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
        loadProductData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Products/GetAll`;
            axios.get(url).then((response) => {
                this.productData = response.data;
                this.totalItems = this.productData.length;
                this.totalPages = Math.ceil(this.totalItems / this.pageSize);
            }).catch((error) => {
                console.log(error.response);
            })
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
        loadCategoryData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Categories/GetAll`;
            axios.get(url).then((response) => {
                this.categoryData = response.data;
            }).catch((error) => {
                console.log(error.response);
            })
        },
        handleSearch(keyword) {
            this.searchKeyword = keyword;
            this.currentPage = 1; // Reset to the first page when a new search is performed
        }
    },
    mounted() {
        this.loadProductData();
        this.loadCategoryData();
    }
}

</script>

<style scoped></style>