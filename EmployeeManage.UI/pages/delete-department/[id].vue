<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="font-medium text-4xl">Delete Department</h1>

        <form class="mt-16">
            <div class="grid gap-6 mb-6 md:grid-cols-3">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Department Name</label>
                    <input type="text" :value="department.departmentName" disabled id="first_name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" >
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Manager</label>
                    <input type="text" :value="department.manager" disabled id="last_name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Memebers</label>
                    <input type="text" :value="department.members" id="company" disabled class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5">
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Delete department</button>
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
            department: [],
        }
    },
    setup(){
        const id = ref(useRoute().params.id);
        return {
            id,
        };
    },
    created(){
        this.fetchDepartment();
    },
    methods:{
        async fetchDepartment(){
            try{
                var response = await axios.get(`https://localhost:7244/api/Department/GetDepartment/${this.id}`);
                this.department = response.data
                console.log(response.data)
            } catch(error){
                console.log('Error fetching departments', error.message)
            }
        }
    }
}
</script>