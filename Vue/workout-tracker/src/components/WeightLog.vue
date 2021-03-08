<template>
    <div class="container-fluweightLog mt-4">
        <h1 class="h1">Weight Log</h1>
        <b-alert :show="loading" variant="info">Loading</b-alert>
        <b-row>
            <b-col>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Date</th>
                            <th>Weight</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="record in records" :key="record.Id">
                            <td>{{ record.Id }}</td>
                            <td>{{ record.Date }}</td>
                            <td>{{ record.Weight }}</td>
                            <td class="text-right">
                                <a href="#" @click.prevent="updateWeightLog(record)">Edit</a>
                                <a href="#" @click.prevent="deleteWeightLog(record.id)">Delete</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </b-col>
            <b-col lg="3">
                <b-card title="New Weight Log">
                    <form @submit.prevent="createWeightLog">
                        <b-form-group label="ID">
                            <b-form-input v-model="model.Id" type="number"></b-form-input>
                        </b-form-group>
                        <b-form-group label="Date">
                            <b-form-input rows="4" v-model="model.Date" type="date"></b-form-input>
                        </b-form-group>
                        <b-form-group label="Weight">
                            <b-form-input v-model="model.Weight" type="number"></b-form-input>
                        </b-form-group>
                        <div>
                            <b-btn type="submit" variant="success">Save Entry</b-btn>
                        </div>
                    </form>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>

<script>
import api from '@/TrackerApi';

export default {
    data() {
        return {
            loading: false,
            records: [],
            model: {}
        };
    },
    async created() {
        this.getAll()
    },
    methods: {
        async getAll() {
            this.loading = true

            try {
                this.records = await api.getAll()
            } finally {
                this.loading = false
            }
        },
        async updateWeightLog(weightLog) {
            this.model = Object.assign({}, weightLog)
        },
        async createWeightLog() {
            const isUpdate = !!this.model.WeightLog;

            if (isUpdate) {
                await api.update(this.model.WeightLog, this.model)
            } else {
                await api.create(this.model)
            }

            this.model = {}

            await this.getAll()
        },
        async deleteWeightLog(weightLog) {
            if (confirm('Do you want to delete this entry?')) {
                if (this.model.WeightLog === weightLog) {
                    this.model = {}
                }

                await api.delete(weightLog)
                await this.getAll()
            }
        }
    }
}
</script>