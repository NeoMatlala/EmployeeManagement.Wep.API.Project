<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Edit Department</h1>

        <form class="mt-16" @submit.prevent="handleSubmit">
            <div class="grid gap-6 mb-6 md:grid-cols-3">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900">Department Name</label>
                    <input type="text" id="first_name" v-model="department.departmentName" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John" required>
                    <small class="text-xs hidden text-red-600">Department Name is required</small>
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900">Manager</label>
                    <input type="text" id="last_name" v-model="department.manager" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Doe" required>
                    <small class="text-xs hidden text-red-600">Manager is required</small>
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Memebers</label>
                    <input type="text" id="company" v-model="department.members" disabled class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Flowbite" required>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update department</button>
                <NuxtLink to="/departments" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
            
        </form>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data(){
        return{
            department : {
                departmentName: '',
                manager: '',
                members: '',
            }
        }
    },
    setup(){
        const id = ref(useRoute().params.id);
        const config = useRuntimeConfig()
        
        return {
            id,
            baseApi: config.public.apiBase
        };
    },
    created(){
        this.fetchDepartment();
    },
    methods:{
        async fetchDepartment(){
            try{
                var response = await axios.get(`${this.baseApi}/api/Department/GetDepartment/${this.id}`);
                this.department = response.data
                console.log(response.data)
            } catch(error){
                console.log('Error fetching departments', error.message)
            }
        },
        async handleSubmit(){
            try{
                const response = await axios.post(`${this.baseApi}/api/Department/UpdateDepartment/${this.id}`, this.department)
                console.log(response.data)
                this.$router.replace('/departments');
            } catch(error) {
                console.log('error updating department', error);
            }
        }
    }
}

</script>
