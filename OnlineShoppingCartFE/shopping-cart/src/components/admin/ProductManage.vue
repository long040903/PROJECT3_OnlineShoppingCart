<template>
    <SidebarAdmin />
    <section id="content">
        <NavbarAdmin />
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Product Manage</h1>
                </div>
            </div>
            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Product Manage</h3>
                        <router-link class="btn-create" to="/admin/create_product">Create</router-link>
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
                                <th>Image</th>
                                <th>Price</th>
                                <th>Description</th>
                                <th>Category</th>
                                <th>Bar Code</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="p in productData" :key="p.id" style="text-align: center;">
                                <td>{{ p.id }}</td>
                                <td>{{ p.productName }}</td>
                                <td><img class="img-manage" :src="p.imageProduct"
                                        style="width:90px; height: 60px; border-radius: 0;"></td>
                                <td>{{ p.price }}</td>
                                <td>{{ p.description }}</td>
                                <td>{{ p.categoryName }}</td>
                                <td>{{ p.barCode }}</td>
                                <td>
                                    <div class="btn-group" role="group" aria-label="Basic example">
                                        <button type="button" class="btn-update"
                                            @click="openUpdateModal(p)">Update</button>
                                        <button type="button" class="btn-delete"
                                            @click="onDeleteClick(p)">Delete</button>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="pagination_section" style="margin-top: 30px;">
                        <a href="#" style="font-weight: bold;" @click="previousPage">
                            << Previous</a>
                                <div class="a-number" v-for="page in Math.ceil(totalItems / pageSize)" :key="page">
                                    <a href="#" title="Algorithm" @click="changePage(page)">
                                        {{ page }}
                                    </a>
                                </div>
                                <a href="#" style="font-weight: bold;" @click="nextPage">Next >></a>
                    </div>
                </div>
            </div>
        </main>

        <!-- Modal for Update Product -->
        <div v-if="showUpdateModal" class="modal">
            <div class="modal-content">
                <span class="close" @click="closeUpdateModal">&times;</span>
                <h2>Update Product</h2>
                <form @submit.prevent="updateProduct">
                    <label for="productName">Product Name</label>
                    <input type="text" id="productName" v-model="currentProduct.productName" required>

                    <label for="price">Price</label>
                    <input type="text" id="price" v-model="currentProduct.price" required>

                    <label for="description">Description</label>
                    <textarea id="description" v-model="currentProduct.description" required></textarea>

                    <label for="barCode">Bar Code</label>
                    <input type="text" id="barCode" v-model="currentProduct.barCode" required>
                    <!-- <textarea id="barCode" v-model="currentProduct.barCode" required></textarea> -->

                    <label for="categoryId">Category</label>
                    <select id="categoryId" v-model="currentProduct.categoryId" required>
                        <option disabled value="">Select Category</option>
                        <option v-for="category in categories" :key="category.id" :value="category.id">
                            {{ category.categoryName }}
                        </option>
                    </select>

                    <label for="imageProduct">Image</label>
                    <input type="file" id="imageProduct" @change="onFileChange">

                    <button type="submit" class="save-modal">Save</button>
                </form>
            </div>
        </div>
    </section>
</template>

<script>
import axios from 'axios';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';
import SidebarAdmin from './SidebarAdmin.vue';
import NavbarAdmin from './NavbarAdmin.vue';

export default {
    name: 'ProductManage',
    components: {
        SidebarAdmin, NavbarAdmin
    },
    data() {
        return {
            productData: [],
            searchKeyword: '',
            pageSize: 3,
            currentPage: 1,
            totalPages: 0,
            totalItems: 0,
            showUpdateModal: false,
            currentProduct: {
                productName: "",
                imageProduct: null,
                price: "",
                description: "",
                barCode: "",
                categoryId: ""
            },
            categories: []
        }
    },
    setup() {
        const success = () => {
            toast("Success !", {
                autoClose: 1000,
                type: "success"
            });
        }
        return { success };
    },
    methods: {
        loadProductData() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Products/GetAll`;
            axios.get(url).then((response) => {
                this.totalItems = response.data.length;
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++;
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                this.productData = response.data.slice(startIndex, endIndex).map(product => {
                    const category = this.categories.find(cat => cat.id === product.categoryId);
                    return {
                        ...product,
                        categoryName: category ? category.categoryName : 'Unknown'
                    };
                });
            }).catch((error) => {
                console.log(error.response);
            });
        },
        loadCategories() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Categories/GetAll`;
            return axios.get(url).then((response) => {
                this.categories = response.data;
            }).catch((error) => {
                console.log(error.response);
            });
        },
        onSearchClick() {
            if (this.searchKeyword.trim() === '') {
                this.loadProductData();
            } else {
                var url = process.env.VUE_APP_BASE_API_URL + `/Products/fullFilter`;
                var requestData = {
                    filterParams: [
                        {
                            colName: "productName",
                            _operator: "like",
                            value: this.searchKeyword
                        }
                    ]
                };

                axios.post(url, requestData)
                    .then(response => {
                        this.productData = response.data;
                        this.totalItems = this.productData.length;
                        this.totalPages = Math.floor(this.totalItems / this.pageSize);
                        if (this.totalItems % this.pageSize !== 0) {
                            this.totalPages++;
                        }
                        this.currentPage = 1;
                    })
                    .catch(error => {
                        console.error('Error during search:', error);
                    });
            }
        },
        changePage(page) {
            this.currentPage = page;
            this.loadProductData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadProductData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadProductData();
            }
        },
        openUpdateModal(product) {
            this.currentProduct = { ...product };
            this.showUpdateModal = true;
        },
        closeUpdateModal() {
            this.showUpdateModal = false;
        },
        updateProduct() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Products/Update`;
            axios.put(url, this.currentProduct)
                .then(response => {
                    this.showUpdateModal = false;
                    this.success();
                    this.loadProductData();
                })
                .catch(error => {
                    console.error('Error updating product:', error);
                });
        },
        onFileChange(event) {
            const file = event.target.files[0];
            if (file) {
                const formData = new FormData();
                formData.append('image', file);

                axios.post(process.env.VUE_APP_BASE_API_URL + '/Products/UploadImage', formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data',
                    },
                })
                    .then(response => {
                        this.currentProduct.imageProduct = response.data.imageUrl;
                    })
                    .catch(error => {
                        console.log('Error uploading image:', error);
                    });
            }
        },
        onDeleteClick(p) {
            if (confirm("Are you sure you want to delete this product?")) {
                var url = process.env.VUE_APP_BASE_API_URL + `/Products/${p.id}`;
                axios.delete(url)
                    .then(response => {
                        this.loadProductData();
                        this.success();
                    })
                    .catch(error => {
                        console.error("Error deleting product:", error);
                        toast.error("Error deleting product. Please try again later.");
                    });
            }
        }
    },
    mounted() {
        this.loadCategories().then(() => {
            this.loadProductData();
        });
    }
}
</script>

<style scoped>
@import '@/assets/style.css';
@import '@/assets/pagination.css';

</style>
