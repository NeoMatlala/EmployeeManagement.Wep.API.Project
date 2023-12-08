<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Delete Employee</h1>

        <form class="mt-16" @submit.prevent="handleDelete">
            <div class="grid gap-10 mb-6 md:grid-cols-2">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Name</label>
                    <input disabled type="text" id="first_name" :value="employee.name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Surname</label>
                    <input disabled type="text" id="last_name" :value="employee.surname" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">ID Number</label>
                    <input disabled type="text" id="company" :value="employee.idNumber" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Job Title</label>
                    <input disabled type="text" id="company" :value="employee.jobTitle" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Department Name</label>
                    <input disabled type="text" id="company" :value="employee.departmentName" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Delete department</button>
                <NuxtLink to="/employees" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data() {
        return {
            employee: {}
        }
    },
    setup(){
        const id = ref(useRoute().params.id);
        return {
            id,
        };
    },
    created() {
        this.fetchEmployee()
    },
    methods: {
        async fetchEmployee() {
            try {
                var response = await axios.get(`https://localhost:7244/api/Employee/${this.id}`)
                //console.log(response.data)
                this.employee = response.data
            } catch (error) {
                console.log("Error getting employee: ", error.message)
            }
        },
        async handleDelete() {
            try {
                var response = await axios.delete(`https://localhost:7244/api/Employee/${this.id}`)
                console.log(response.data)
                this.$router.replace('/employees');
            } catch (error) {
                console.log("Error deleting employee: ", error.message)
            }
        }
    }
}
</script>