<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Create Product</h1>
                    <ul class="breadcrumb">

                        <li>/</li>
                        <li>
                            <router-link class="active" to="/admin/productmanage">Back to manage</router-link>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Create Product</h3>
                    </div>
                    <form>
                        <ul class="form-style-1">
                            <li>
                                <label>Product Name <span class="required">*</span></label>
                                <input type="text" name="field1" class="field-long" placeholder="Product Name"
                                    v-model="currentProduct.productName" />
                            </li>
                            <li>
                                <label>Image <span class="required">*</span></label>
                                <input type="file" class="field-long" id="imageProduct" placeholder="First"
                                    @change="onFileChange" />
                            </li>
                            <li>
                                <label>Price <span class="required">*</span></label>
                                <input type="text" name="" class="field-long" placeholder="Price"
                                    v-model="currentProduct.price" />
                            </li>
                            <li>
                                <label>Description <span class="required">*</span></label>
                                    <textarea name="field5" id="field5" class="field-long field-textarea" v-model="currentProduct.description"></textarea>
                            </li>
                            <li>
                                <label>BarCode <span class="required">*</span></label>
                                <input type="text" name="" class="field-long" placeholder="BarCode"
                                    v-model="currentProduct.barCode" />
                            </li>
                            <li>
                                <label>Category</label>
                                <select v-model="currentProduct.categoryId" name="field4" class="field-select">
                                    <option disabled value="" selected>Select Category</option>
                                    <option v-for="category in categories" :key="category.id" :value="category.id">{{
                                        category.categoryName }}</option>
                                </select>
                            </li>
                            <li>
                            </li>
                        </ul>
                    </form>
                    <button type="button" class="button-submit-product" @click="onCreateClick()">Submit</button>
                </div>
            </div>
        </main>
        <!-- MAIN -->
    </section>
    <!-- CONTENT -->
</template>

<script>
import axios from 'axios';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';
import router from '../../router.js';

import SidebarAdmin from './SidebarAdmin.vue';
import NavbarAdmin from './NavbarAdmin.vue';

export default {
    name: '',
    components: {
        SidebarAdmin, NavbarAdmin
    },
    data() {
        return {
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
        getCategories() {
            var url = process.env.VUE_APP_BASE_API_URL + `/Categories/GetAll`;
            axios.get(url).then((response) => {
                this.categories = response.data;
            }).catch((error) => {
                console.log(error.response);
            })
        },
        onFileChange(event) {
            const file = event.target.files[0];
            if (file) {
                // Kiểm tra phần mở rộng của file
                const validExtensions = ['.png', '.jpg', '.jpeg'];
                const fileName = file.name;
                const fileExtension = fileName.substring(fileName.lastIndexOf('.')).toLowerCase();

                if (!validExtensions.includes(fileExtension)) {
                    alert('Vui lòng chọn một file ảnh có định dạng .png, .jpg hoặc .jpeg!');
                    return;
                }

                const formData = new FormData();
                formData.append('image', file);

                // Gọi API để upload ảnh
                axios.post(process.env.VUE_APP_BASE_API_URL + '/Products/UploadImage', formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data',
                    },
                })
                    .then(response => {
                        // Lưu URL ảnh trả về từ API vào currentProduct.imageProduct
                        this.currentProduct.imageProduct = response.data.imageUrl;
                        console.log(this.currentProduct.imageProduct);
                    })
                    .catch(error => {
                        console.log('Error uploading image:', error);
                    });
            }
        },
        onCreateClick() {
            if (!this.currentProduct.productName || !this.currentProduct.price || !this.currentProduct.description || !this.currentProduct.barCode || !this.currentProduct.categoryId) {
                alert('Please fill all required fields!');
                return;
            }
            var url = process.env.VUE_APP_BASE_API_URL + `/Products/Create`
            axios.post(url, this.currentProduct).then((respone) => {
                console.log(respone.data);
                router.push({ name: 'ProductManageView' });
            }).catch((error) => {
                console.log(error)
            })
        }
    },
    mounted() {
        this.getCategories();
        import('../../assets/script')
    }
}
</script>
<style scoped>
@import '@/assets/forminput.css';
@import '@/assets/style.css';
</style>