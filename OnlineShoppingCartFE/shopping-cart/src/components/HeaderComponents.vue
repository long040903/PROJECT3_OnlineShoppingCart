<template>
    <header class="header-style-1">

        <!-- ============================================== TOP MENU ============================================== -->
        <div class="top-bar animate-dropdown">
            <div class="container">
                <div class="header-top-inner">
                    <div class="cnt-account">
                        <ul class="list-unstyled">
                            <li v-if="username"><a href="#"><i class="icon fa fa-user"></i>{{ username }}</a></li>
                            <li v-else><router-link to="/login"><i class="icon fa fa-lock"></i>Login</router-link></li>
                            <li><a href="#"><i class="icon fa fa-heart"></i>Wishlist</a></li>
                            <li><a href="#"><i class="icon fa fa-shopping-cart"></i>My Cart</a></li>
                            <li><a href="#"><i class="icon fa fa-check"></i>Checkout</a></li>
                            <li v-if="username" @click="logout"><a href="#"><i
                                        class="icon fa fa-sign-out"></i>Logout</a></li>
                            <!-- <li ><router-link to="/login"><i class="icon fa fa-lock"></i>Login</router-link></li> -->
                        </ul>
                    </div>
                    <!-- /.cnt-account -->

                    <div class="cnt-block">
                        <ul class="list-unstyled list-inline">
                            <li class="dropdown dropdown-small"> <a href="#" class="dropdown-toggle"
                                    data-hover="dropdown" data-toggle="dropdown"><span class="value">USD </span><b
                                        class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">USD</a></li>
                                    <li><a href="#">INR</a></li>
                                    <li><a href="#">GBP</a></li>
                                </ul>
                            </li>
                            <li class="dropdown dropdown-small"> <a href="#" class="dropdown-toggle"
                                    data-hover="dropdown" data-toggle="dropdown"><span class="value">English </span><b
                                        class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">English</a></li>
                                    <li><a href="#">French</a></li>
                                    <li><a href="#">German</a></li>
                                </ul>
                            </li>
                        </ul>
                        <!-- /.list-unstyled -->
                    </div>
                    <!-- /.cnt-cart -->
                    <div class="clearfix"></div>
                </div>
                <!-- /.header-top-inner -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.header-top -->
        <!-- ============================================== TOP MENU : END ============================================== -->
        <div class="main-header">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-3 logo-holder">
                        <!-- ============================================================= LOGO ============================================================= -->
                        <!-- <div class="logo"> <a href="home.html"> <img src="../assets/img/logoart.png" alt="logo"> </a>
                        </div> -->
                        <!-- /.logo -->
                        <!-- ============================================================= LOGO : END ============================================================= -->
                    </div>
                    <!-- /.logo-holder -->

                    <div class="col-xs-12 col-sm-12 col-md-7 top-search-holder">
                        <!-- /.contact-row -->
                        <!-- ============================================================= SEARCH AREA ============================================================= -->
                        <div class="search-area" style="height:45px">
                            <form @submit.prevent="onSearchClick" style="display:inline">
                                <div class="control-group">
                                    <input class="search-field" placeholder="Search here..." v-model="searchKeyword">
                                    <!-- <a class="search-button" href="#" style="height: 45px"></a> -->
                                    <button class="search-button" type="submit" style="height: 45px"></button>
                                </div>
                            </form>
                        </div>
                        <!-- /.search-area -->
                        <!-- ============================================================= SEARCH AREA : END ============================================================= -->
                    </div>
                    <!-- /.top-search-holder -->

                    <div class="col-xs-12 col-sm-12 col-md-2 animate-dropdown top-cart-row">
                        <!-- ============================================================= SHOPPING CART DROPDOWN ============================================================= -->

                        <div class="dropdown dropdown-cart"> <router-link to="/cart" class="dropdown-toggle lnk-cart"
                                data-toggle="dropdown">
                                <div class="items-cart-inner">
                                    <div class="basket"> <i class="glyphicon glyphicon-shopping-cart"></i> </div>
                                    <div class="total-price-basket"> <span class="lbl">cart</span> <span
                                            class="total-price"> </span> </div>
                                </div>
                            </router-link>
                            <!-- /.dropdown-menu-->
                        </div>
                        <!-- /.dropdown-cart -->

                        <!-- ============================================================= SHOPPING CART DROPDOWN : END============================================================= -->
                    </div>
                    <!-- /.top-cart-row -->
                </div>
                <!-- /.row -->

            </div>
            <!-- /.container -->

        </div>
        <!-- /.main-header -->

        <!-- ============================================== NAVBAR ============================================== -->
        <div class="header-nav animate-dropdown">
            <div class="container">
                <div class="yamm navbar navbar-default" role="navigation">
                    <div class="navbar-header">
                        <button data-target="#mc-horizontal-menu-collapse" data-toggle="collapse"
                            class="navbar-toggle collapsed" type="button">
                            <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span
                                class="icon-bar"></span> <span class="icon-bar"></span> </button>
                    </div>
                    <div class="nav-bg-class">
                        <div class="navbar-collapse collapse" id="mc-horizontal-menu-collapse">
                            <div class="nav-outer" style="display: flex">
                                <ul class="nav navbar-nav">
                                    <li class="dropdown"> <router-link to="/" data-hover="dropdown"
                                            class="dropdown-toggle" data-toggle="dropdown">Home</router-link>
                                    </li>
                                </ul>
                                <ul class="nav navbar-nav" v-for="c in categoryData" :key="c.id">
                                    <li class="dropdown"> <router-link
                                            :to="{ name: 'CategoryDetailsPageView', params: { categoryId: c.id } }" 
                                            data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown">{{
                                                c.categoryName }}</router-link>
                                    </li>
                                </ul>

                                <!-- /.navbar-nav -->
                                <div class="clearfix"></div>
                            </div>
                            <!-- /.nav-outer -->
                        </div>
                        <!-- /.navbar-collapse -->

                    </div>
                    <!-- /.nav-bg-class -->
                </div>
                <!-- /.navbar-default -->
            </div>
            <!-- /.container-class -->

        </div>
        <!-- /.header-nav -->
        <!-- ============================================== NAVBAR : END ============================================== -->

    </header>
</template>
<script>
import axios from 'axios';

export default {
    name: "HeaderHomePage",
    data() {
        return {
            categoryData: [],
            searchKeyword: '',
            username: ''
        }
    },
    methods: {
        loadCategoryData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Categories/GetAll`;
            axios.get(url).then((response) => {
                this.categoryData = response.data;
                console.log(this.categoryData);
            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSearchClick() {
            this.$emit('search', this.searchKeyword);
        },
        logout() {
            localStorage.removeItem('username');
            this.username = '';
            localStorage.removeItem('customerToken');
            this.$router.push('/');
        }
    },
    mounted() {
        this.loadCategoryData();
        this.username = localStorage.getItem('username');
    }
}
</script>

<style></style>