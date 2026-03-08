import { ref, computed, onMounted } from 'vue';
const machines = ref([]);
const alertCount = computed(() => machines.value.filter(m => m.HasAlert).length);
onMounted(async () => {
    const data = await fetch('/api/machines').then(r => r.json());
    machines.value = data.map((m) => ({
        MachineId: m.machineId,
        LatestStatus: m.latestStatus,
        LatestTemperatureC: m.latestTemperatureC,
        LatestLastErrorCode: m.LatestLastErrorCode,
        HasAlert: m.hasAlert
    }));
});
const __VLS_ctx = {
    ...{},
    ...{},
};
let __VLS_components;
let __VLS_intrinsics;
let __VLS_directives;
__VLS_asFunctionalElement1(__VLS_intrinsics.div, __VLS_intrinsics.div)({});
__VLS_asFunctionalElement1(__VLS_intrinsics.h2, __VLS_intrinsics.h2)({});
__VLS_asFunctionalElement1(__VLS_intrinsics.p, __VLS_intrinsics.p)({});
(__VLS_ctx.machines.length);
__VLS_asFunctionalElement1(__VLS_intrinsics.p, __VLS_intrinsics.p)({});
(__VLS_ctx.alertCount);
__VLS_asFunctionalElement1(__VLS_intrinsics.table, __VLS_intrinsics.table)({
    border: "1",
});
__VLS_asFunctionalElement1(__VLS_intrinsics.tr, __VLS_intrinsics.tr)({});
__VLS_asFunctionalElement1(__VLS_intrinsics.th, __VLS_intrinsics.th)({});
__VLS_asFunctionalElement1(__VLS_intrinsics.th, __VLS_intrinsics.th)({});
__VLS_asFunctionalElement1(__VLS_intrinsics.th, __VLS_intrinsics.th)({});
__VLS_asFunctionalElement1(__VLS_intrinsics.th, __VLS_intrinsics.th)({});
for (const [m] of __VLS_vFor((__VLS_ctx.machines))) {
    __VLS_asFunctionalElement1(__VLS_intrinsics.tr, __VLS_intrinsics.tr)({
        key: (m.MachineId),
        ...{ style: ({ background: m.HasAlert ? '#ffcccc' : '' }) },
    });
    __VLS_asFunctionalElement1(__VLS_intrinsics.td, __VLS_intrinsics.td)({});
    (m.MachineId);
    __VLS_asFunctionalElement1(__VLS_intrinsics.td, __VLS_intrinsics.td)({});
    (m.LatestStatus);
    __VLS_asFunctionalElement1(__VLS_intrinsics.td, __VLS_intrinsics.td)({});
    (m.LatestTemperatureC);
    __VLS_asFunctionalElement1(__VLS_intrinsics.td, __VLS_intrinsics.td)({});
    (m.LatestLastErrorCode);
    // @ts-ignore
    [machines, machines, alertCount,];
}
// @ts-ignore
[];
const __VLS_export = (await import('vue')).defineComponent({});
export default {};
