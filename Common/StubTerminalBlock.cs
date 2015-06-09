using System;
using System.Text;
using Sandbox.ModAPI.Ingame;
using VRage.Utils;
using Sandbox.ModAPI.Interfaces;
using System.Collections.Generic;
using VRageMath;

namespace SpaceEngineersScripts.Common
{
	public class StubTerminalBlock : IMyTerminalBlock
	{
		public string CustomInfo {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool HasLocalPlayerAccess ()
		{
			throw new NotImplementedException ();
		}

		public bool HasPlayerAccess (long playerId)
		{
			throw new NotImplementedException ();
		}

		public void RequestShowOnHUD (bool enable)
		{
			throw new NotImplementedException ();
		}

		public void SetCustomName (string text)
		{
			throw new NotImplementedException ();
		}

		public void SetCustomName (StringBuilder text)
		{
			throw new NotImplementedException ();
		}

		public void GetActions (List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect)
		{
			throw new NotImplementedException ();
		}

		public void SearchActionsOfName (string name, List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect)
		{
			throw new NotImplementedException ();
		}

		public ITerminalAction GetActionWithName (string name)
		{
			throw new NotImplementedException ();
		}

		public ITerminalProperty GetProperty (string id)
		{
			throw new NotImplementedException ();
		}

		public void GetProperties (List<ITerminalProperty> resultList, Func<ITerminalProperty, bool> collect)
		{
			throw new NotImplementedException ();
		}

		public string CustomName {
			get {
				throw new NotImplementedException ();
			}
		}

		public string CustomNameWithFaction {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual string DetailedInfo {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool ShowOnHUD {
			get {
				throw new NotImplementedException ();
			}
		}

		public event Action<VRage.ModAPI.IMyEntity> OnClose;
		public event Action<VRage.ModAPI.IMyEntity> OnClosing;
		public event Action<VRage.ModAPI.IMyEntity> OnMarkForClose;
		public event Action<VRage.ModAPI.IMyEntity> OnPhysicsChanged;

		public string GetOwnerFactionTag ()
		{
			throw new NotImplementedException ();
		}

		public Sandbox.Common.MyRelationsBetweenPlayerAndBlock GetPlayerRelationToOwner ()
		{
			throw new NotImplementedException ();
		}

		public Sandbox.Common.MyRelationsBetweenPlayerAndBlock GetUserRelationToOwner (long playerId)
		{
			throw new NotImplementedException ();
		}

		public void UpdateIsWorking ()
		{
			throw new NotImplementedException ();
		}

		public void UpdateVisual ()
		{
			throw new NotImplementedException ();
		}

		public string GetFriendlyName ()
		{
			throw new NotImplementedException ();
		}

		public void Close ()
		{
			throw new NotImplementedException ();
		}

		public void Delete ()
		{
			throw new NotImplementedException ();
		}

		public VRage.ObjectBuilders.MyObjectBuilder_EntityBase GetObjectBuilder (bool copy)
		{
			throw new NotImplementedException ();
		}

		public void BeforeSave ()
		{
			throw new NotImplementedException ();
		}

		public VRage.ModAPI.IMyEntity GetTopMostParent (Type type)
		{
			throw new NotImplementedException ();
		}

		public void SetLocalMatrix (VRageMath.Matrix localMatrix, object source)
		{
			throw new NotImplementedException ();
		}

		public void GetChildren (List<VRage.ModAPI.IMyEntity> children, Func<VRage.ModAPI.IMyEntity, bool> collect)
		{
			throw new NotImplementedException ();
		}

		public VRageMath.Vector3 GetDiffuseColor ()
		{
			throw new NotImplementedException ();
		}

		public bool IsVisible ()
		{
			throw new NotImplementedException ();
		}

		public void DebugDraw ()
		{
			throw new NotImplementedException ();
		}

		public void DebugDrawInvalidTriangles ()
		{
			throw new NotImplementedException ();
		}

		public void EnableColorMaskForSubparts (bool enable)
		{
			throw new NotImplementedException ();
		}

		public void SetColorMaskForSubparts (VRageMath.Vector3 colorMaskHsv)
		{
			throw new NotImplementedException ();
		}

		public float GetDistanceBetweenCameraAndBoundingSphere ()
		{
			throw new NotImplementedException ();
		}

		public float GetDistanceBetweenCameraAndPosition ()
		{
			throw new NotImplementedException ();
		}

		public float GetLargestDistanceBetweenCameraAndBoundingSphere ()
		{
			throw new NotImplementedException ();
		}

		public float GetSmallestDistanceBetweenCameraAndBoundingSphere ()
		{
			throw new NotImplementedException ();
		}

		public void OnRemovedFromScene (object source)
		{
			throw new NotImplementedException ();
		}

		public void OnAddedToScene (object source)
		{
			throw new NotImplementedException ();
		}

		public VRageMath.MatrixD GetViewMatrix ()
		{
			throw new NotImplementedException ();
		}

		public VRageMath.MatrixD GetWorldMatrixNormalizedInv ()
		{
			throw new NotImplementedException ();
		}

		public void SetWorldMatrix (VRageMath.MatrixD worldMatrix, object source)
		{
			throw new NotImplementedException ();
		}

		public VRageMath.Vector3D GetPosition ()
		{
			throw new NotImplementedException ();
		}

		public void SetPosition (VRageMath.Vector3D pos)
		{
			throw new NotImplementedException ();
		}

		public Vector3? GetIntersectionWithLineAndBoundingSphere (ref LineD line, float boundingSphereRadiusMultiplier)
		{
			throw new NotImplementedException ();
		}

		public bool GetIntersectionWithSphere (ref BoundingSphereD sphere)
		{
			throw new NotImplementedException ();
		}

		public void GetTrianglesIntersectingSphere (ref BoundingSphereD sphere, Vector3? referenceNormalVector, float? maxAngle, List<MyTriangle_Vertex_Normals> retTriangles, int maxNeighbourTriangles)
		{
			throw new NotImplementedException ();
		}

		public bool DoOverlapSphereTest (float sphereRadius, VRageMath.Vector3D spherePos)
		{
			throw new NotImplementedException ();
		}

		public void AddToGamePruningStructure ()
		{
			throw new NotImplementedException ();
		}

		public void RemoveFromGamePruningStructure ()
		{
			throw new NotImplementedException ();
		}

		public void UpdateGamePruningStructure ()
		{
			throw new NotImplementedException ();
		}

		public VRage.ObjectBuilders.SerializableDefinitionId BlockDefinition {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CheckConnectionAllowed {
			get {
				throw new NotImplementedException ();
			}
		}

		public IMyCubeGrid CubeGrid {
			get {
				throw new NotImplementedException ();
			}
		}

		public string DefinitionDisplayNameText {
			get {
				throw new NotImplementedException ();
			}
		}

		public float DisassembleRatio {
			get {
				throw new NotImplementedException ();
			}
		}

		public string DisplayNameText {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsBeingHacked {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsFunctional {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsWorking {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.Vector3I Max {
			get {
				throw new NotImplementedException ();
			}
		}

		public float Mass {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.Vector3I Min {
			get {
				throw new NotImplementedException ();
			}
		}

		public int NumberInGrid {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.MyBlockOrientation Orientation {
			get {
				throw new NotImplementedException ();
			}
		}

		public long OwnerId {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.Vector3I Position {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MyEntityComponentContainer Components {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MyPhysicsComponentBase Physics {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MyPositionComponentBase PositionComp {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MyRenderComponentBase Render {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MyEntityComponentBase GameLogic {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MyHierarchyComponentBase Hierarchy {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.Components.MySyncComponentBase SyncObject {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRage.ModAPI.EntityFlags Flags {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public long EntityId {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public string Name {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool MarkedForClose {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool Closed {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool Save {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.ObjectBuilders.MyPersistentEntityFlags2 PersistentFlags {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.ModAPI.MyEntityUpdateEnum NeedsUpdate {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRage.ModAPI.IMyEntity Parent {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.Matrix LocalMatrix {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool NearFlag {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool CastShadows {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool FastCastShadowResolve {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool NeedsResolveCastShadow {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public float MaxGlassDistSq {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool NeedsDraw {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool NeedsDrawFromParent {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool Transparent {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool ShadowBoxLod {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool SkipIfTooSmall {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool Visible {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool InScene {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool InvalidateOnMove {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingBoxD WorldAABB {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingBoxD WorldAABBHr {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.MatrixD WorldMatrix {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.MatrixD WorldMatrixInvScaled {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.MatrixD WorldMatrixNormalizedInv {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingSphereD WorldVolume {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingSphereD WorldVolumeHr {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsVolumetric {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingBox LocalAABB {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingBox LocalAABBHr {
			get {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.BoundingSphere LocalVolume {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.Vector3 LocalVolumeOffset {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public VRageMath.Vector3 LocationForHudMarker {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsCCDForProjectiles {
			get {
				throw new NotImplementedException ();
			}
		}

		public string DisplayName {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
	}
}