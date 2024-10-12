<template>
    <div class="limiter" id="login">
        <div class="container-login100"
            style="background-image:url(https://image.freepik.com/free-photo/happy-woman-doing-online-shopping-home_329181-4301.jpg)">
            <div class="container">
                <div class="row" style="margin-left: 0px;">
                    <div class="col-md-3"></div>
                    <div class="col-md-6" style=" width:auto !important;">
                        <div class="login_topimg">
                        </div>
                        <div class="wrap-login100">
                            <span style="margin-bottom: 30px" class="login100-form-title "> Login Admin </span>
                            <form class="login100-form validate-form" @submit.prevent="login" style="margin: auto;">
                                <div class="wrap-input100 validate-input m-b-16"
                                    data-validate="Valid email is required: ex@abc.xyz">
                                    <input class="input100" type="text" id="loginUsername" v-model="loginForm.username"
                                        placeholder="Username">
                                    <span class="focus-input100"></span>
                                    <span class="symbol-input100">
                                        <span class="glyphicon glyphicon-user"></span>
                                    </span>
                                </div>
                                <div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                                    <input class="input100" type="password" id="loginPassword"
                                        v-model="loginForm.password" placeholder="Password">
                                    <span class="focus-input100"></span>
                                    <span class="symbol-input100">
                                        <span class="glyphicon glyphicon-lock"></span>
                                    </span>
                                </div>

                                <div class="container-login100-form-btn p-t-25">
                                    <button type="submit" class="login100-form-btn">Login</button>
                                </div>
                                <!-- Hiển thị thông báo khi đăng nhập không thành công -->
                                <div style="text-align: center; width: 100%; margin: 0 auto; margin-top: 10px" v-if="error" class="alert alert-danger mt-3" role="alert">
                                    {{ error }}
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios';

export default {
    name: 'LoginAdmin',
    props: {
        msg: String
    },
    data() {
        return {
            loginForm: {
                username: '',
                password: ''
            },
            error: '' // Thêm biến error để lưu thông báo lỗi
        };
    },
    methods: {
        async login() {
            if (!this.loginForm.username || !this.loginForm.password) {
                this.error = 'Username and password are required!';
                return;
            }

            try {
                var url = `${process.env.VUE_APP_BASE_API_URL}/Authentications/Login`;
                const response = await axios.post(url, {
                    username: this.loginForm.username,
                    password: this.loginForm.password
                });

                if (response.status === 200) {
                    const data = response.data;
                    const roles = data.roles;

                    console.log(roles);


                    if (roles.includes('ADMIN')) {
                        // localStorage.setItem('token', data.token);
                        localStorage.setItem('adminToken', data.token);
                        console.log('Đăng nhập thành công:', data);
                        this.$router.push('/admin').then(() => {
                            window.location.reload();
                        });
                    } else {
                        console.log('Đăng nhập thành công nhưng không phải admin:', data);
                        this.error = 'Bạn không có quyền truy cập vào trang admin.';
                    }
                } else {
                    this.error = response.data.message || 'Sai thông tin đăng nhập hoặc mật khẩu!';
                }
            } catch (error) {
                console.error('Đã xảy ra lỗi khi đăng nhập:', error);
                this.error = error.response?.data.message || 'Sai thông tin đăng nhập hoặc mật khẩu!';
            }
        }
    },

    created() {
        console.log('Component created');
    }
}

</script>
<style scoped>
@import '@/assets/loginadmin.css';
</style>