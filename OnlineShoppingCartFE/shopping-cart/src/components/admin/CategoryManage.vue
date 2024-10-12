<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Category Manage</h1>
                </div>
            </div>

            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Category Manage</h3>
                        <router-link class="btn-create" to="/admin/create_category">Create</router-link>
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
                                <th>Name</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="c in categoryData" :key="c.id" style="text-align: center;">
                                <td>{{ c.id }}</td>
                                <td>{{ c.categoryName }}</td>
                                <td>
                                    <div class="btn-group" role="group" aria-label="Basic example">
                                        <button type="button" class="btn-update" @click="openUpdateModal(c)">Update</button>
                                        <button type="button" class="btn-delete" @click="onDeleteClick(c.id)">Delete</button>
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

        <!-- Modal for Update Category -->
        <div v-if="showUpdateModal" class="modal">
            <div class="modal-content">
                <span class="close" @click="closeUpdateModal">&times;</span>
                <h2>Update Category</h2>
                <form @submit.prevent="updateCategory">
                    <label for="categoryName">Category Name</label>
                    <input type="text" id="categoryName" v-model="currentCategory.categoryName" required>
                    <button type="submit" class="save-modal">Save</button>
                </form>
            </div>
        </div>
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
            categoryData: [],
            searchKeyword: '',
            pageSize: 3,
            currentPage: 1,
            totalPages: 0,
            totalItems: 0,
            showUpdateModal: false,
            currentCategory: {
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
        loadCategoryData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Categories/GetAll`;
            axios.get(url).then((response) => {
                this.totalItems = response.data.length;
                this.totalPages = Math.ceil(this.totalItems / this.pageSize);

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                this.categoryData = response.data.slice(startIndex, endIndex);
            }).catch((error) => {
                console.log(error.response);
            })
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadCategoryData();
            } else {
                var url = process.env.VUE_APP_BASE_API_URL + `/Categories/fullFilter`;
                var requestData = {
                    filterParams: [
                        {
                            colName: "categoryName",
                            _operator: "like",
                            value: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.categoryData = response.data;
                        this.totalItems = this.categoryData.length;
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
            this.loadCategoryData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadCategoryData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadCategoryData();
            }
        },
        openUpdateModal(category) {
            this.currentCategory = { ...category };
            this.showUpdateModal = true;
        },
        closeUpdateModal() {
            this.showUpdateModal = false;
        },
        updateCategory() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Categories/Update`;
            axios.put(url, this.currentCategory)
                .then(response => {
                    this.showUpdateModal = false;
                    this.success();
                    this.loadCategoryData();
                })
                .catch(error => {
                    console.error('Error updating category:', error);
                });
        },
        onDeleteClick(categoryId) {
            if (confirm("Are you sure you want to delete this category?")) {
                var url = process.env.VUE_APP_BASE_API_URL + `/Categories/${categoryId}`;
                axios.delete(url)
                    .then(response => {
                        this.loadCategoryData();
                        this.success();
                    })
                    .catch(error => {
                        console.error("Error deleting category:", error);
                        toast.error("Error deleting category. Please try again later.");
                    });
            }
        }
    },
    mounted() {
        this.loadCategoryData();
        import('../../assets/script');
    }
}
</script>

<style scoped>
@import '@/assets/style.css';
@import '@/assets/pagination.css';
</style>
