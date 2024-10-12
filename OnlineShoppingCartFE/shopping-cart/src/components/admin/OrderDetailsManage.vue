<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Order Details Manage</h1>
                </div>
            </div>

            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Order Details Manage</h3>
                    </div>
                    <table>
                        <thead>
                            <tr class="header-text">
                                <th>Bill Code</th>
                                <th>Product Name</th>
                                <th>Quantity</th>
                                <th>Total Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="detail in orderDetailsData" :key="detail.productId" style="text-align: center;">
                                <td>{{ detail.billId }}</td>
                                <td>{{ detail.productName }}</td>
                                <td>{{ detail.quantity }}</td>
                                <td>{{ formatCurrency(detail.price) }}</td>
                            </tr>
                        </tbody>
                        <div class="total-price" style="font-size: 20px; font-style: italic;">
                            Total Price: {{ calculateTotalPrice() }}
                        </div>
                    </table>
                </div>
            </div>

        </main>

        <!-- MAIN -->
    </section>
    <!-- CONTENT -->
</template>

<script>
import axios from 'axios';
import SidebarAdmin from './SidebarAdmin.vue';
import NavbarAdmin from './NavbarAdmin.vue';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

export default {
    name: 'OrderDetailsManage',
    components: {
        SidebarAdmin, NavbarAdmin
    },
    props: ["billId"],
    data() {
        return {
            orderDetailsData: []
        }
    },
    setup(props) {
        const success = () => {
            toast("Success!", {
                autoClose: 1000,
                type: "success"
            });
        }

        return { success };
    },
    methods: {
        loadOrderDetailsData() {
            // const billId = this.$route.params.billId;
            var url = process.env.VUE_APP_BASE_API_URL + `/BillDetails/details/${this.billId}`;
            axios.get(url).then((response) => {
                this.orderDetailsData = response.data;
                console.log(this.orderDetailsData);
            }).catch((error) => {
                console.log(error.response);
            })
        },
        calculateTotalPrice() {
            // Tính tổng giá của tất cả các sản phẩm
            const totalPrice = this.orderDetailsData.reduce((total, detail) => {
                return total + detail.price;
            }, 0);

            // Định dạng tổng giá tiền sang VND
            return totalPrice.toLocaleString('vi-VN', {
                style: 'currency',
                currency: 'VND'
            });
        },
        formatCurrency(price) {
            return price.toLocaleString('vi-VN', {
                style: 'currency',
                currency: 'VND'
            });
        },
    },
    mounted() {
        this.loadOrderDetailsData();
        import('../../assets/script');
    }
}
</script>

<style scoped>
@import '@/assets/style.css';
@import '@/assets/pagination.css';
</style>
