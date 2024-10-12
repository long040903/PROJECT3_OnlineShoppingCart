<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Dashboard</h1>
                    <ul class="breadcrumb">
                        <li>
                            <a href="#">Dashboard</a>
                        </li>

                    </ul>
                </div>
            </div>

            <ul class="box-info">
                <li>
                    <i class='bx fa fa-shopping-cart'></i>
                    <span class="text">
                        <h3>{{ totalOrders }}</h3>
                        <p>Total Order</p>
                    </span>
                </li>
                <li>
                    <i class='bx fa fa-user'></i>
                    <span class="text">
                        <h3>{{ totalCustomers }}</h3>
                        <p>Total Customers</p>
                    </span>
                </li>
                <li>
                    <i class='bx fa fa-money'></i>
                    <span class="text">
                        <h3>{{ formattedTotalSales }}</h3>
                        <p>Total Sales</p>
                    </span>
                </li>
            </ul>


            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Recent Orders</h3>
                        <i class='bx bx-search'></i>
                        <i class='bx bx-filter'></i>
                    </div>
                    <table>
                        <thead>
                            <tr>
                                <th style="text-align: center;">Id</th>
                                <th style="text-align: center;">Date Order</th>
                                <th style="text-align: center;">Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr style="text-align: center;"v-for="(order, index) in orderData.slice(0, 6)" :key="order.id">
                                <td>
                                    <p>{{ order.id }}</p>
                                </td>
                                <td>{{ order.date }}</td>
                                <td><span class="status completed">Completed</span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="todo">
                    <div class="head">
                        <h3>Todos</h3>
                        <i class='bx bx-plus'></i>
                        <i class='bx bx-filter'></i>
                    </div>
                    <ul class="todo-list">
                        <li class="completed">
                            <p>Todo List</p>
                            <i class='bx bx-dots-vertical-rounded'></i>
                        </li>
                        <li class="completed">
                            <p>Todo List</p>
                            <i class='bx bx-dots-vertical-rounded'></i>
                        </li>
                        <li class="not-completed">
                            <p>Todo List</p>
                            <i class='bx bx-dots-vertical-rounded'></i>
                        </li>
                        <li class="completed">
                            <p>Todo List</p>
                            <i class='bx bx-dots-vertical-rounded'></i>
                        </li>
                        <li class="not-completed">
                            <p>Todo List</p>
                            <i class='bx bx-dots-vertical-rounded'></i>
                        </li>
                    </ul>
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

export default {
    name: '',
    components: {
        SidebarAdmin, NavbarAdmin
    },
    data() {
        return {
            orderData: [],
            customerData: [],
            billDetailsData: []
        }
    },
    computed: {
        totalOrders() {
            return this.orderData.length; // Tính tổng số đơn hàng
        },
        totalCustomers() {
            return this.customerData.length;
        },
        totalSales() {
            // Tính tổng số tiền
            return this.billDetailsData.reduce((sum, billDetail) => sum + billDetail.price, 0);
        },
        formattedTotalSales() {
            // Định dạng số tiền theo tiền Việt Nam Đồng
            return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(this.totalSales);
        }
    },
    methods: {
        loadOrderData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Bills/GetAll`;
            axios.get(url).then((response) => {
                this.orderData = response.data;
                console.log(this.orderData);
            }).catch((error) => {
                console.log(error.response);
            })
        },
        loadCustomerData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Customers/GetAll`;
            axios.get(url).then((response) => {
                this.customerData = response.data;
            }).catch((error) => {
                console.log(error.response);
            })
        },
        loadTotalPriceData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/BillDetails/GetAll`;
            axios.get(url).then((response) => {
                this.billDetailsData = response.data;
            }).catch((error) => {
                console.log(error.response);
            })
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            if (isNaN(date.getTime())) {
                return 'Invalid Date'; // hoặc giá trị mặc định nếu cần
            }
            return new Intl.DateTimeFormat('vi-VN', {
                year: 'numeric',
                month: '2-digit',
                day: '2-digit'
            }).format(date);
        },
    },
    mounted() {
        import('../../assets/script')
        this.loadOrderData();
        this.loadCustomerData();
        this.loadTotalPriceData();

    }
}
</script>
<style scoped>
@import '@/assets/style.css';
</style>