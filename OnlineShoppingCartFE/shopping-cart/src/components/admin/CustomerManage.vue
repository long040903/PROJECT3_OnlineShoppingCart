<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Customer Manage</h1>
                </div>
            </div>

            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Customer Manage</h3>
                        <!-- <router-link class="btn-create" to="/admin/create_category">Create</router-link> -->
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
                                <th>ID</th>
                                <th>FullName</th>
                                <th>Email</th>
                                <th>PhoneNumber</th>
                                <th>Address</th>
                                <th>Note</th>
                                <!-- <th>Action</th> -->
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="c in customerData" :key="c.id" style="text-align: center;">
                                <td>{{ c.id }}</td>
                                <td>{{ c.fullName }}</td>
                                <td>{{ c.email }}</td>
                                <td>{{ c.phoneNumber }}</td>
                                <td>{{ c.address }}</td>
                                <td>{{ c.note }}</td>

                                <!-- <td>
                                    <div class="btn-group" role="group" aria-label="Basic example">
                                        <button type="button" class="btn-update" @click="openUpdateModal(c)">Update</button>
                                        <button type="button" class="btn-delete" @click="onDeleteClick(c.id)">Delete</button>
                                    </div>
                                </td> -->
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

        <!-- Modal for Update Category -->
        <!-- <div v-if="showUpdateModal" class="modal">
            <div class="modal-content">
                <span class="close" @click="closeUpdateModal">&times;</span>
                <h2>Update Category</h2>
                <form @submit.prevent="updateCustomer">
                    <label for="categoryName">Category Name</label>
                    <input type="text" id="categoryName" v-model="currentCategory.categoryName" required>
                    <button type="submit" class="save-modal">Save</button>
                </form>
            </div>
        </div> -->
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
    name: 'CustomerManage',
    components: {
        SidebarAdmin, NavbarAdmin
    },
    data() {
        return {
            customerData: [],
            searchKeyword: '',
            pageSize: 3,
            currentPage: 1,
            totalPages: 0,
            totalItems: 0,
            showUpdateModal: false,
            currentCustomer: {
                id: null,
                fullName: ''
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
        loadCustomerData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Customers/GetAll`;
            axios.get(url).then((response) => {
                this.totalItems = response.data.length;
                this.totalPages = Math.ceil(this.totalItems / this.pageSize);

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                this.customerData = response.data.slice(startIndex, endIndex);
            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadCustomerData();
            } else {
                var url = process.env.VUE_APP_BASE_API_URL + `/Customers/fullFilter`;
                var requestData = {
                    filterParams: [
                        {
                            colName: "fullName",
                            _operator: "like",
                            value: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.customerData = response.data;
                        this.totalItems = this.customerData.length;
                        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
                        this.currentPage = 1;
                    })
                    .catch(error => {
                        console.error('Lỗi khi tìm kiếm khách hàng:', error);
                    });
            }
        },
        changePage(page) {
            this.currentPage = page;
            this.loadCustomerData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadCustomerData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadCustomerData();
            }
        },
        openUpdateModal(customer) {
            this.currentCustomer = { ...customer };
            this.showUpdateModal = true;
        },
        closeUpdateModal() {
            this.showUpdateModal = false;
        },
        updateCustomer() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Customers/Update`;
            axios.put(url, this.currentCustomer)
                .then(response => {
                    this.showUpdateModal = false;
                    this.success();
                    this.loadCustomerData();
                })
                .catch(error => {
                    console.error('Error updating customer:', error);
                });
        },
        onDeleteClick(categoryId) {
            if (confirm("Are you sure you want to delete this customer?")) {
                var url = process.env.VUE_APP_BASE_API_URL + `/Customers/${customerId}`;
                axios.delete(url)
                    .then(response => {
                        this.loadCustomerData();
                        this.success();
                    })
                    .catch(error => {
                        console.error("Error deleting customer:", error);
                        toast.error("Error deleting customer. Please try again later.");
                    });
            }
        }
    },
    mounted() {
        this.loadCustomerData();
        import('../../assets/script');
    }
}
</script>

<style scoped>
@import '@/assets/style.css';
@import '@/assets/pagination.css';
</style>
