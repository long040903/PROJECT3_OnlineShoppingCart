<template>
    <SidebarAdmin />
    <!-- CONTENT -->
    <section id="content">
        <NavbarAdmin />

        <!-- MAIN -->
        <main>
            <div class="head-title">
                <div class="left">
                    <h1>Create Category</h1>
                    <ul class="breadcrumb">
                        
                        <li>/</li>
                        <li>
                            <router-link class="active" to="/admin/categorymanage">Back to manage</router-link>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="table-data">
                <div class="order">
                    <div class="head">
                        <h3>Create Category</h3>
                    </div>
                    <form>
                        <ul class="form-style-1">
                            <li>
                                <label>Category Name <span class="required">*</span></label>
                                <input type="text" name="field1" class="field-long" placeholder="Category Name" v-model="currentCategory.categoryName"/>
                            </li>                                         
                            <li>
                            </li>
                        </ul>
                    </form>
                    <button type="button" class="button-submit-category" @click="onCreateClick()">Submit</button>

                </div>
            </div>
        </main>
        <!-- MAIN -->
    </section>
    <!-- CONTENT -->
</template>

<script>
import axios from 'axios';
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
            currentCategory: {
                id: 0,
                categoryName: "Name",
            }
        }
    },
    methods: {
        onCreateClick() {
            if (this.currentCategory.id == 0) {
                var url = process.env.VUE_APP_BASE_API_URL + `/Categories/Create`
                axios.post(url, this.currentCategory).then((respone) => {
                    console.log(respone.data);
                    router.push({ name: 'CategoryManageView' });
                }).catch((error) => {
                    console.log(error)
                })
            }
        }
    },
    mounted() {
        import('../../assets/script')
    }
}
</script>
<style scoped>
@import '@/assets/forminput.css';
@import '@/assets/style.css';

</style>