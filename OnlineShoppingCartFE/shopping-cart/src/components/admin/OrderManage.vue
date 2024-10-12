<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Order Manage</h1>
                </div>
            </div>

            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Order Manage</h3>
                    </div>
                    <form @submit.prevent="onSearchClick">
                        <div class="form-input">
                            <input type="search" placeholder="Search..." v-model="searchKeyword">
                            <button type="submit" class="search-btn"><i class='fa fa-search'></i></button>
                        </div>
                    </form>
                    <table>
                        <thead>
                            <tr class="header-text">
                                <th>BillId</th>
                                <th>BillDate</th>
                                <th>CustomerName</th>
                                <th>PhoneNumber</th>
                                <th>Address</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="o in orderData" :key="o.id" style="text-align: center;">
                                <td>{{ o.billId }}</td>
                                <td>{{ o.billDate }}</td>
                                <td>{{ o.customerFullName }}</td>
                                <td>{{ o.customerPhoneNumber }}</td>
                                <td>{{ o.customerAddress }}</td>
                                <td>
                                    <div class="btn-group" role="group" aria-label="Basic example">
                                        <button type="button" class="btn-update" @click="viewDetails(o.billId)">View Details</button>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="pagination_section" style="margin-top: 30px;">
                        <a href="#" style="font-weight: bold;" @click="previousPage">
                            << Previous </a>
                                <div class="a-number" v-for="page in Math.ceil(totalItems / pageSize)" :key="page">
                                    <a href="#" title="Algorithm" @click="changePage(page)">
                                        {{ page }}
                                    </a>
                                </div>
                                <a href="#" style="font-weight: bold;" @click="nextPage">
                                    Next >>
                                </a>
                    </div>
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
    name: 'CategoryManage',
    components: {
        SidebarAdmin, NavbarAdmin
    },
    data() {
        return {
            orderData: [],
            searchKeyword: '',
            pageSize: 3,
            currentPage: 1,
            totalPages: 0,
            totalItems: 0,
            showUpdateModal: false,
            currentOrder: {
                id: null,
                categoryName: ''
            }
        }
    },
    setup() {
        const success = () => {
            toast("Success!", {
                autoClose: 1000,
                type: "success"
            });
        }
        return { success };
    },
    methods: {
        loadOrderData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Customers/GetCustomerAndBill`;
            axios.get(url).then((response) => {
                this.totalItems = response.data.length;
                this.totalPages = Math.ceil(this.totalItems / this.pageSize);

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                this.orderData = response.data.slice(startIndex, endIndex);
            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadOrderData();
            } else {
                var url = process.env.VUE_APP_BASE_API_URL + `/Customers/fullFilter`;
                var requestData = {
                    filterParams: [
                        {
                            colName: "customerName",
                            _operator: "like",
                            value: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.orderData = response.data;
                        this.totalItems = this.orderData.length;
                        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
                        this.currentPage = 1;
                    })
                    .catch(error => {
                        console.error('Lỗi khi tìm kiếm danh mục:', error);
                    });
            }
        },
        changePage(page) {
            this.currentPage = page;
            this.loadOrderData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadOrderData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadOrderData();
            }
        },
        viewDetails(billId) {
            console.log(billId);
            this.$router.push({ name: 'OrderDetailsManageView', params: { billId } });
        }
    },
    mounted() {
        this.loadOrderData();
        import('../../assets/script');
    }
}
</script>

<style scoped>
@import '@/assets/style.css';
@import '@/assets/pagination.css';
</style>
