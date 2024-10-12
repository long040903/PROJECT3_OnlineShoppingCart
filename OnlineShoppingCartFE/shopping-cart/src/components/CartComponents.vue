<template>
    <HeaderComponents />

    <div class="breadcrumb">
        <div class="container">
            <div class="breadcrumb-inner">
                <ul class="list-inline list-unstyled">
                    <li><a href="#">Home</a></li>
                    <li class='active'>Shopping Cart</li>
                </ul>
            </div><!-- /.breadcrumb-inner -->
        </div><!-- /.container -->
    </div><!-- /.breadcrumb -->

    <div class="body-content outer-top-xs">
        <div class="container">
            <div class="row ">
                <div class="shopping-cart">
                    <div class="shopping-cart-table ">
                        <div class="table-responsive">
                            <table class="table" v-if="cart.length">
                                <thead>
                                    <tr>
                                        <th class="cart-romove item">Remove</th>
                                        <th class="cart-description item">Image</th>
                                        <th class="cart-product-name item">Product Name</th>
                                        <th class="cart-qty item">Quantity</th>
                                        <th class="cart-sub-total item">Subtotal</th>
                                        <th class="cart-total last-item">Grandtotal</th>
                                    </tr>
                                </thead><!-- /thead -->
                                <tfoot>
                                    <tr>
                                        <td colspan="7">
                                            <div class="shopping-cart-btn">
                                                <span class="">
                                                    <router-link to="/"
                                                        class="btn btn-upper btn-primary outer-left-xs">Continue
                                                        Shopping</router-link>
                                                </span>
                                            </div><!-- /.shopping-cart-btn -->
                                        </td>
                                    </tr>
                                </tfoot>
                                <tbody>
                                    <tr v-for="(product, index) in formattedCart" :key="index">
                                        <td class="romove-item"><a @click.prevent="removeFromCart(index)" href="#"
                                                title="cancel" class="icon"><i class="fa fa-trash-o"></i></a></td>
                                        <td class="cart-image">
                                            <a class="entry-thumbnail" href="detail.html">
                                                <img :src="product.imageProduct" alt="">
                                            </a>
                                        </td>
                                        <td class="cart-product-name-info">
                                            <h4 class='cart-product-description'><a href="detail.html">{{
                                                product.productName }}</a>
                                            </h4>
                                        </td>
                                        <td class="cart-product-quantity">
                                            <div class="cart-quantity">
                                                <div class="quant-input">
                                                    <div class="arrows">
                                                        <div @click="increaseQuantity(index)"
                                                            class="arrow plus gradient"><span class="ir"><i
                                                                    class="icon fa fa-sort-asc"></i></span></div>
                                                        <div @click="decreaseQuantity(index)"
                                                            class="arrow minus gradient"><span class="ir"><i
                                                                    class="icon fa fa-sort-desc"></i></span></div>
                                                    </div>
                                                    <input type="number" min="1" v-model="cart[index].quantity">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="cart-product-sub-total"><span class="cart-sub-total-price">{{
                                            product.formattedSubtotal }}</span></td>
                                        <td class="cart-product-grand-total"><span class="cart-grand-total-price">{{
                                            product.formattedSubtotal }}</span></td>
                                    </tr>
                                </tbody><!-- /tbody -->

                            </table><!-- /table -->
                            <div v-else>
                                <h3 style="text-align: center;">No items in cart.</h3>
                            </div>
                        </div>
                    </div><!-- /.shopping-cart-table -->

                    <div class="col-md-4 col-sm-12 cart-shopping-total" style="float: right;">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        <div class="cart-sub-total">
                                            Subtotal<span class="inner-left-md">{{ formattedSubtotal }}</span>
                                        </div>
                                        <div class="cart-grand-total">
                                            Grand Total<span class="inner-left-md">{{ formattedSubtotal }}</span>
                                        </div>
                                    </th>
                                </tr>
                            </thead><!-- /thead -->
                            <tbody>
                                <tr>
                                    <td>
                                        <div class="cart-checkout-btn pull-right">

                                        </div>
                                    </td>
                                </tr>
                            </tbody><!-- /tbody -->
                        </table><!-- /table -->
                    </div><!-- /.cart-shopping-total -->

                    <div class="col-md-8 col-sm-12 form-xac-nhan">
                        <h3>Thông tin nhận hàng</h3>
                        <form @submit.prevent="submitForm">
                            <div class="row">
                                <div class="col-md-6">
                                    <span>Họ và tên</span>
                                    <input type="text" placeholder="Họ và tên" v-model="currentCustomers.fullName"
                                        required>
                                </div>
                                <div class="col-md-6">
                                    <span>Số điện thoại</span>
                                    <input type="text" placeholder="Số điện thoại"
                                        v-model="currentCustomers.phoneNumber" required>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <span>Địa chỉ</span>
                                    <input type="text" placeholder="Địa chỉ" v-model="currentCustomers.address"
                                        required>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <span>Email (Tùy chọn)</span>
                                    <input type="email" placeholder="Email" v-model="currentCustomers.email" required>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <span>Ghi chú đơn hàng (Nếu có)</span>
                                    <div>
                                        <textarea name="" id="" v-model="currentCustomers.note" required></textarea>
                                    </div>
                                </div>
                            </div>
                            <button type="submit" class="submit-form">Xác nhận
                                đặt hàng</button>
                        </form>
                        

                    </div>
                </div><!-- /.shopping-cart -->
            </div> <!-- /.row -->
        </div><!-- /.container -->
    </div><!-- /.body-content -->

    <FooterComponents />

</template>

<script>
import axios from 'axios';
import HeaderComponents from './HeaderComponents';
import FooterComponents from './FooterComponents';
import Swal from 'sweetalert2';
import moment from 'moment';

export default {
    name: "Cart",
    components: {
        HeaderComponents, FooterComponents
    },
    data() {
        return {
            cart: [],
            currentCustomers: {
                fullName: "",
                email: "",
                phoneNumber: "",
                address: "",
                note: ""
            },
            order: []
        }
    },
    computed: {
        formattedCart() {
            return this.cart.map(product => ({
                ...product,
                formattedPrice: new Intl.NumberFormat('vi-VN', {
                    style: 'currency',
                    currency: 'VND'
                }).format(product.price),
                formattedSubtotal: new Intl.NumberFormat('vi-VN', {
                    style: 'currency',
                    currency: 'VND'
                }).format(product.price * product.quantity)
            }));
        },
        formattedSubtotal() {
            const total = this.cart.reduce((acc, product) => acc + product.price * product.quantity, 0);
            return new Intl.NumberFormat('vi-VN', {
                style: 'currency',
                currency: 'VND'
            }).format(total);
        }
    },
    watch: {
        '$store.state.isLoggedIn'(newValue) {
            // Khi trạng thái đăng nhập thay đổi, kiểm tra và cập nhật các trường required
            this.updateRequiredFields(newValue);
        }
    },
    methods: {
        removeFromCart(index) {
            this.cart.splice(index, 1);
            localStorage.setItem('cart', JSON.stringify(this.cart));
        },
        updateGrandtotal() {
            let grandTotal = 0;
            this.cart.forEach(product => {
                grandTotal += product.price * product.quantity;
            });
            this.grandTotal = grandTotal;
        },
        increaseQuantity(index) {
            if (isNaN(this.cart[index].quantity) || typeof this.cart[index].quantity !== 'number') {
                this.cart[index].quantity = 1;
            }
            this.cart[index].quantity++;
            this.updateGrandtotal();
        },
        decreaseQuantity(index) {
            if (isNaN(this.cart[index].quantity) || typeof this.cart[index].quantity !== 'number') {
                this.cart[index].quantity = 1;
            }
            if (this.cart[index].quantity > 1) {
                this.cart[index].quantity--;
                this.updateGrandtotal();
            }
        },
        async submitForm() {
            if (!this.cart.length) {
                Swal.fire({
                    icon: 'info',
                    title: 'Giỏ hàng của bạn trống!',
                    text: 'Vui lòng thêm sản phẩm vào giỏ hàng trước khi đặt hàng.',
                }).then(() => {
                    // Chuyển hướng đến trang chủ và load lại trang
                    this.$router.push('/');
                    // window.location.reload();
                });
                return; // Ngăn chặn các hành động tiếp theo nếu giỏ hàng rỗng
            }

            const isLoggedIn = localStorage.getItem('customerToken');

            if (!isLoggedIn) {
                // Hiển thị thông báo bắt đăng nhập
                Swal.fire({
                    icon: 'error',
                    title: 'Bạn cần đăng nhập!',
                    text: 'Vui lòng đăng nhập để tiếp tục đặt hàng.',
                    showCancelButton: true,
                    confirmButtonText: 'Đăng nhập',
                    cancelButtonText: 'Đóng',
                    cancelButtonColor: '#d33',
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Chuyển hướng đến trang đăng nhập
                        this.$router.push('/login');
                    }
                });
            } else {
                try {
                    // Gửi thông tin khách hàng lên server
                    const customerUrl = process.env.VUE_APP_BASE_API_URL + "/Customers/Create";
                    const customerResponse = await axios.post(customerUrl, this.currentCustomers);
                    const customerId = customerResponse.data.id;

                    console.log(customerId);

                    // Lấy dữ liệu giỏ hàng từ localStorage
                    const cartData = localStorage.getItem('cart');
                    let cartItems = [];
                    if (cartData) {
                        cartItems = JSON.parse(cartData);
                    }

                    console.log(this.cartData);

                    // Tạo danh sách billDetails từ giỏ hàng
                    const billDetail = cartItems.map(product => {
                        const updatedQuantity = this.cart.find(item => item.id === product.id).quantity;
                        return {
                            productId: product.id,
                            quantity: updatedQuantity,
                            price: product.price * updatedQuantity,
                            billId: 0,
                            product: product
                        };
                    });

                    console.log(this.billDetail);

                    // Tạo đối tượng đơn hàng
                    this.order = {
                        id: 0,
                        code: "ddfgregter",
                        date: moment(new Date()).format("YYYY-MM-DDTHH:mm:ss"),
                        customerId: customerId,
                        billDetails: billDetail
                    };


                    // Gửi đơn hàng lên server
                    var url = process.env.VUE_APP_BASE_API_URL + `/Bills/InsertFullDetail`;
                    axios.post(url, this.order).then((response) => {
                        console.log(response.data);
                        Swal.fire({
                            icon: 'success',
                            title: 'Đặt hàng thành công!',
                            text: 'Đơn hàng của bạn đã được gửi.'
                        }).then(() => {
                            localStorage.removeItem('cart');
                            window.location.reload();
                        });
                    }).catch((error) => {
                        console.log(error.response);
                        Swal.fire({
                            icon: 'error',
                            title: 'Lỗi!',
                            text: 'Có lỗi xảy ra khi gửi đơn hàng.',
                        });

                    })
                } catch (error) {
                    console.error(error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi!',
                        text: 'Có lỗi xảy ra khi gửi đơn hàng.',
                    });
                }
            }
        },
        updateRequiredFields(isLoggedIn) {
            const formInputs = document.querySelectorAll('.form-xac-nhan input[required]');
            formInputs.forEach(input => {
                input.required = isLoggedIn;
            });
        }
    },
    mounted() {
        const cartData = localStorage.getItem('cart');
        if (cartData) {
            this.cart = JSON.parse(cartData);
        }
    }
}
</script>

<style scoped>
.col-md-8.col-sm-12.form-xac-nhan {
    padding: 20px;
    margin: 20px auto;
    border-radius: 8px;
}

h3 {
    font-size: 24px;
    margin-bottom: 20px;
    color: #333;
}

form span {
    display: block;
    margin-bottom: 8px;
    font-weight: bold;
    color: #555;
}

form input[type="text"],
form input[type="email"],
form textarea {
    width: 100%;
    padding: 10px;
    margin-bottom: 20px;
    border: 1px solid #ccc;
    border-radius: 4px;
    font-size: 16px;
    color: #333;
}

form textarea {
    resize: vertical;
    height: 100px;
}

form .row {
    margin-bottom: 20px;
}

form .col-md-6 {
    width: 48%;
    display: inline-block;
    margin-right: 2%;
}

form .col-md-6:last-child {
    margin-right: 0;
}

.submit-form {
    background-color: #28a745;
    color: #fff;
    padding: 15px 20px;
    border: none;
    border-radius: 4px;
    font-size: 18px;
    cursor: pointer;
    transition: background-color 0.3s;
}

.submit-form:hover {
    background-color: #218838;
}

@media (max-width: 768px) {
    form .col-md-6 {
        width: 100%;
        margin-right: 0;
    }
}
</style>